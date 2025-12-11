using System;
using System.Xml.Serialization;

namespace TrainBuilderApp
{
    public class PassengerWagon : Wagon
    {
        public int SeatCapacity { get; set; }

        public int CurrentPassengers { get; set; }

        public double AvgBaggagePerPassengerKg { get; set; }

        public PassengerWagon() { }

        public PassengerWagon(string id, double tareKg, ComfortLevel comfort,
            int seatCapacity, int currentPassengers, double avgBaggagePerPassengerKg)
            : base(id, tareKg, comfort)
        {
            SeatCapacity = seatCapacity;
            CurrentPassengers = currentPassengers;
            AvgBaggagePerPassengerKg = avgBaggagePerPassengerKg;
        }

        public override int PassengerCount => CurrentPassengers;

        public override double BaggageWeightKg => CurrentPassengers * AvgBaggagePerPassengerKg;

        public override string ToString()
        {
            return $"{base.ToString()} Seats={SeatCapacity} Passengers={CurrentPassengers} Baggage={BaggageWeightKg}kg";
        }
    }
}
