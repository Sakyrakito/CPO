using System;

namespace TrainBuilderApp
{
    public class BaggageWagon : Wagon
    {
        public double LoadedBaggageKg { get; set; }
        
        public double MaxCapacityKg { get; set; }

        public BaggageWagon() { }

        public BaggageWagon(string id, double tareKg, ComfortLevel comfort,
            double loadedBaggageKg, double maxCapacityKg)
            : base(id, tareKg, comfort)
        {
            LoadedBaggageKg = loadedBaggageKg;
            MaxCapacityKg = maxCapacityKg;
        }

        public override double BaggageWeightKg => LoadedBaggageKg;

        public override string ToString()
        {
            return $"{base.ToString()} LoadedBaggage={LoadedBaggageKg}kg Capacity={MaxCapacityKg}kg";
        }
    }
}
