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
    static public class DeserializeCoordinates
    {
        static public List<State> GetStates()
        {
            string path = @"D:\CPO\Semester 2\Project_1\states.json";

            string json = File.ReadAllText(path);
            var statesJson = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            if (statesJson is null)
            {
                throw new ArgumentNullException(paramName: nameof(statesJson));
            }

            List<State> states = new List<State>();
            foreach (var entry in statesJson)
            {
                JsonElement shapeData = entry.Value;

                State state = new State();
                state.Shapes = NormalizeShapeData(shapeData);
                state.StateCode = entry.Key;

                states.Add(state);
            }

            return states;
        }

        static List<Shape> NormalizeShapeData(JsonElement shapeJson)
        {
            List<Shape> shapes = new List<Shape>();

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

        static bool IsMultiShape(JsonElement shapeJson)
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

        static Shape ParseShape(JsonElement shapeJson)
        {
            Shape shape = new Shape();

            foreach (JsonElement poligonJson in shapeJson.EnumerateArray())
            {
                Polygon poligon = new Polygon();

                foreach (JsonElement pointJson in poligonJson.EnumerateArray())
                {
                    poligon.AddPoint(new Point(pointJson[0].GetDouble(), pointJson[1].GetDouble()));
                }

                shape.AddPolygon(poligon);
            }

            return shape;
        }
    }
}
