using Project_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    public class MapDataManager
    {
        readonly List<State> states;
        private (double minLon, double maxLon, double minLat, double maxLat) bounds;
        private readonly Dictionary<string, List<List<(int x, int y)>>> statesOnScreen = [];

        public MapDataManager(int width, int height)
        {
            states = DeserializeUSAMap.GetStates();
            FindBounds();
            CalculateStatesOnScreen(width, height);
        }

        public List<State> GetStates
        {
            get { return states; }
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
                    List<(int x, int y)> polynom = new();

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
    }
}
