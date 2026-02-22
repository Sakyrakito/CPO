using Project_1.Models;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Project_1
{
    public class Project
    {
        static void Main(string[] args)
        {
            var states = DeserializeCoordinates.GetStates();

        }

        static public (double minLon, double maxLon, double minLat, double maxLat) FindBounds(List<State> states)
        {
            double minLon = double.MaxValue;
            double maxLon = double.MinValue;
            double minLat = double.MaxValue;
            double maxLat = double.MinValue;

            foreach (var state in states)
            {
                foreach (var shape in state.Shapes)
                {
                    foreach (var polygon in shape.Polygons)
                    {
                        foreach (var point in polygon.Points)
                        {
                            minLon = Math.Min(minLon, point.Longtitude);
                            maxLon = Math.Max(maxLon, point.Longtitude);

                            minLat = Math.Min(minLat, point.Latitude);
                            maxLat = Math.Max(maxLat, point.Latitude);
                        }
                    }
                }
            }

            return (minLon, maxLon, minLat, maxLat);
        }
    }
}