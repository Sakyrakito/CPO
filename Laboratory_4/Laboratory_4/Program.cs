using System;
using System.IO;
using TrainBuilderApp;

class Program
{
    static void Main()
    {
        var builder = new TrainBuilder("TransContinental Express")
            .AddPassengerWagon("P1", 18000, ComfortLevel.High, 80, 75, 18.0)
            .AddPassengerWagon("P2", 17800, ComfortLevel.Medium, 90, 60, 15.0)
            .AddRestaurantWagon("R1", 15000, ComfortLevel.Luxury, 40, 20, 7.5)
            .AddBaggageWagon("B1", 12000, ComfortLevel.Low, 4000, 5000)
            .AddMailWagon("M1", 11000, ComfortLevel.Low, 1200, 5)
            .AddPassengerWagon("P3", 17500, ComfortLevel.High, 60, 55, 12.0);

        var train = builder.Build();

        Console.WriteLine(train);
        Console.WriteLine();
        Console.WriteLine("Wagons by comfort (descending):");
        foreach (var w in train.GetWagonsSortedByComfortDescending())
        {
            Console.WriteLine("  " + w.ToString());
        }

        Console.WriteLine();
        Console.WriteLine($"Find wagons with passengers in range [50,80]:");
        var found = train.FindWagonsByPassengerRange(50, 80);
        foreach (var w in found)
        {
            Console.WriteLine("  " + w.ToString());
        }

        var outFile = Path.Combine(Directory.GetCurrentDirectory(), "train_data.xml");
        SaveToFileXML.SaveToFile(train, outFile);
        Console.WriteLine();
        Console.WriteLine($"Train serialized to: {outFile}");

        var loaded = SaveToFileXML.LoadFromFile(outFile);
        Console.WriteLine();
        Console.WriteLine("Loaded train:");
        Console.WriteLine(loaded);
    }
}
