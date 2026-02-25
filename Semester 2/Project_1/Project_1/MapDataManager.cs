using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project_1
{
    public class MapDataManager
    {
        readonly List<State> states;
        private (double minLon, double maxLon, double minLat, double maxLat) bounds;
        private readonly Dictionary<string, List<List<(int x, int y)>>> statesOnScreen = [];
        private readonly Dictionary<string, Point> centerOfStates = [];

        public MapDataManager(int width, int height)
        {
            states = DeserializeUSAMap.GetStates();
            FindBounds();
            CalculateStatesOnScreen(width, height);
            FindCenterOfStates();
        }

        public List<State> GetStates
        {
            get { return states; }
        }

        public Dictionary<string, Point> GetCenterOfStates
        {
            get { return  centerOfStates; }
        }

        public Dictionary<string, List<List<(int x, int y)>>> GetShapes()
        {
            return statesOnScreen;
        }

        private void CalculateStatesOnScreen(int width, int height)
        {
            foreach (var state in states)
            {
                foreach (var shape in state.Shapes)
                {
                    List<(int x, int y)> polynom = [];

                    for (int i = 0; i < shape.Points.Count; i++)
                    {
                        var currentPoint = shape.Points[i];

                        var (x, y) = ProjectMercator(currentPoint.Longtitude,
                            currentPoint.Latitude, width, height);

                        polynom.Add((x, y));
                    }

                    if (!statesOnScreen.TryGetValue(state.StateCode, out List<List<(int x, int y)>>? value))
                    {
                        value = [];
                        statesOnScreen[state.StateCode] = value;
                    }

                    value.Add(polynom);
                }
            }
        }

        private void FindCenterOfStates()
        {
            foreach (var (stateCode, state) in statesOnScreen)
            {
                Point center = new(0.0, 0.0);
                double bestDist = -1;

                foreach (var shape in state)
                {
                    int minX = shape.Min(p => p.x);
                    int maxX = shape.Max(p => p.x);
                    int minY = shape.Min(p => p.y);
                    int maxY = shape.Max(p => p.y);

                    double stepX = (maxX - minX) / 30.0;
                    double stepY = (maxY - minY) / 30.0;

                    for (double x = minX; x < maxX; x += stepX)
                    {
                        for (double y = minY; y < maxY; y += stepY)
                        {
                            Point point = new(x, y);
                            if (PointInsideShape(point, shape))
                            {
                                double dist = FindNearestDist(point, shape);

                                if (dist - bestDist > double.Epsilon)
                                {
                                    bestDist = dist;
                                    center = point;
                                }
                            }
                        }
                    }
                }

                centerOfStates[stateCode] = center;
            }
        }

        private static double FindNearestDist(Point point, List<(int x, int y)> shape)
        {
            double x0 = point.Longtitude;
            double y0 = point.Latitude;
            double minDist = double.MaxValue;

            for (int i = 0; i < shape.Count; i++)
            {
                double x1 = shape[i].x;
                double y1 = shape[i].y;
                double x2 = shape[(i + 1) % shape.Count].x;
                double y2 = shape[(i + 1) % shape.Count].y;

                double dx = x2 - x1;
                double dy = y2 - y1;

                if (Math.Abs(dx) <= double.Epsilon && Math.Abs(dy) <= double.Epsilon)
                    continue;

                double t = ((x0 - x1) * dx + (y0 - y1) * dy) / (dx * dx + dy * dy);

                double dist;
                if (t < 0)
                {
                    dist = Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
                }
                else if (t > 1)
                {
                    dist = Math.Sqrt((x0 - x2) * (x0 - x2) + (y0 - y2) * (y0 - y2));
                }
                else
                {
                    double projX = x1 + t * dx;
                    double projY = y1 + t * dy;

                    dist = Math.Sqrt((x0 - projX) * (x0 - projX) + (y0 - projY) * (y0 - projY));
                }

                if (dist - minDist < double.Epsilon)
                {
                    minDist = dist;
                }
            }

            return minDist;
        }

        private void FindBounds()
        {
            double minLon = double.MaxValue;
            double maxLon = double.MinValue;
            double minLat = double.MaxValue;
            double maxLat = double.MinValue;

            foreach (var state in states)
            {
                foreach (var shape in state.Shapes)
                {
                    foreach (var point in shape.Points)
                    {
                        minLon = Math.Min(minLon, point.Longtitude);
                        maxLon = Math.Max(maxLon, point.Longtitude);

                        minLat = Math.Min(minLat, point.Latitude);
                        maxLat = Math.Max(maxLat, point.Latitude);
                    }
                }
            }

            bounds = (minLon, maxLon, minLat, maxLat);
        }

        private (int x, int y) ProjectMercator(double lon, double lat, int width, int height)
        {
            double scaleForX = 2.5;
            double latRad = lat * Math.PI / 180.0;
            double minLatRad = bounds.minLat * Math.PI / 180.0;
            double maxLatRad = bounds.maxLat * Math.PI / 180.0;

            double mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));

            double minMerc = Math.Log(Math.Tan((Math.PI / 4) + (minLatRad / 2)));
            double maxMerc = Math.Log(Math.Tan((Math.PI / 4) + (maxLatRad / 2)));

            double xPerc = (lon - bounds.minLon) / (bounds.maxLon - bounds.minLon) * scaleForX;
            int x = (int)(xPerc * width);

            double yPerc = (mercN - minMerc) / (maxMerc - minMerc);
            int y = (int)((1.0 - yPerc) * height);

            return (x, y);
        }

        private static bool PointInsideShape(Point point, List<(int x, int y)> shape)
        {
            int numberOfIntersection = 0;

            double x0 = point.Longtitude;
            double y0 = point.Latitude;

            for (int i = 0; i < shape.Count; i++)
            {
                double x1 = shape[i].x;
                double y1 = shape[i].y;

                double x2 = shape[(i + 1) % shape.Count].x;
                double y2 = shape[(i + 1) % shape.Count].y;

                if ((y1 - y0 > double.Epsilon) != (y2 - y0 > double.Epsilon))
                {
                    double xIntersect = x1 + (x2 - x1) * (y0 - y1) / (y2 - y1);

                    if (xIntersect - x0 >= double.Epsilon)
                    {
                        numberOfIntersection++;
                    }
                }
            }

            return (numberOfIntersection % 2 == 1);
        }
    }
}
