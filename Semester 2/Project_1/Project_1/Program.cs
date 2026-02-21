using Project_1;
using Project_1.Models;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Text.Json;

public class Project
{
    static void Main(string[] args)
    {
        var states = DeserializeCoordinates.GetStates();

        Console.WriteLine(states.Count);
    }
}