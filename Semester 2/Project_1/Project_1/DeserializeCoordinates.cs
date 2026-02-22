using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_1
{
    public class DeserializeCoordinates
    {
        static public List<State> GetStates()
        {
            string path = @"D:\CPO\Semester 2\Project_1\Project_1\bin\Debug\net8.0\states.json";

            string json = File.ReadAllText(path);
            var statesJson = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            if (statesJson is null)
            {
                throw new ArgumentNullException(nameof(statesJson));
            }

            List<State> states = [];
            foreach (var entry in statesJson)
            {
                JsonElement shapeData = entry.Value;

                State state = new()
                {
                    Shapes = NormalizeShapeData(shapeData),
                    StateCode = entry.Key
                };

                states.Add(state);
            }

            return states;
        }

        static private List<Shape> NormalizeShapeData(JsonElement shapeJson)
        {
            List<Shape> shapes = [];

            if (IsMultiShape(shapeJson))
            {
                foreach (JsonElement polygonJson in shapeJson.EnumerateArray())
                {
                    shapes.Add(ParseShape(polygonJson));
                }
            }
            else
            {
                shapes.Add(ParseShape(shapeJson));
            }

            return shapes;
        }

        static private bool IsMultiShape(JsonElement shapeJson)
        {
            try
            {
                return shapeJson[0][0][0].ValueKind == JsonValueKind.Array;
            }
            catch
            {
                return false;
            }
        }

        static private Shape ParseShape(JsonElement shapeJson)
        {
            Shape shape = new();

            foreach (JsonElement poligonJson in shapeJson.EnumerateArray())
            {
                Polygon poligon = new();

                foreach (JsonElement pointJson in poligonJson.EnumerateArray())
                {
                    Point point = new(pointJson[0].GetDouble(), pointJson[1].GetDouble());
                    poligon.AddPoint(point);
                }

                shape.AddPolygon(poligon);
            }

            return shape;
        }
    }
}
