using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainBuilderApp
{
    public class Train
    {
        public string Name { get; set; }

        public List<Wagon> Wagons { get; set; } = new List<Wagon>();

        public Train() { }

        public Train(string name)
        {
            Name = name;
        }

        public void AddWagon(Wagon w) => Wagons.Add(w);

        public int GetTotalPassengers()
        {
            return Wagons.Sum(w => w.PassengerCount);
        }

        public double GetTotalBaggageWeightKg()
        {
            return Wagons.Sum(w => w.BaggageWeightKg);
        }

        public List<Wagon> GetWagonsSortedByComfortDescending()
        {
            return Wagons.OrderByDescending(w => w.Comfort).ToList();
        }

        public List<Wagon> FindWagonsByPassengerRange(int minPassengers, int maxPassengers)
        {
            return Wagons.Where(w => w.PassengerCount >= minPassengers && w.PassengerCount <= maxPassengers)
                         .ToList();
        }

        public override string ToString()
        {
            return $"Train '{Name}' - Wagons: {Wagons.Count} TotalPassengers: {GetTotalPassengers()} TotalBaggageKg: {GetTotalBaggageWeightKg():F2}kg";
        }
    }
}
