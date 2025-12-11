using System;

namespace TrainBuilderApp
{
    public class RestaurantWagon : Wagon
    {
        public int DiningSeats { get; set; }

        public int CurrentCustomers { get; set; }

        public double AvgBaggagePerCustomerKg { get; set; }

        public RestaurantWagon() { }

        public RestaurantWagon(string id, double tareKg, ComfortLevel comfort,
            int diningSeats, int currentCustomers, double avgBaggagePerCustomerKg)
            : base(id, tareKg, comfort)
        {
            DiningSeats = diningSeats;
            CurrentCustomers = currentCustomers;
            AvgBaggagePerCustomerKg = avgBaggagePerCustomerKg;
        }

        public override int PassengerCount => CurrentCustomers;

        public override double BaggageWeightKg => CurrentCustomers * AvgBaggagePerCustomerKg;

        public override string ToString()
        {
            return $"{base.ToString()} DiningSeats={DiningSeats} Customers={CurrentCustomers} Baggage={BaggageWeightKg}kg";
        }
    }
}
