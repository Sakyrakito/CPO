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
            var states = DeserializeUSAMap.GetStates();
            
            foreach (var state in states)
            {
                foreach (var shape in state.Shapes)
                {
                    Console.WriteLine(shape.Points.Count);
                }
            }

        }
    }
}