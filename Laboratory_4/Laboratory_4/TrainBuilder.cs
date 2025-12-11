using System;
using System.Collections.Generic;

namespace TrainBuilderApp
{
    public class TrainBuilder
    {
        private Train _train;

        public TrainBuilder(string name)
        {
            _train = new Train(name);
        }

        public TrainBuilder AddPassengerWagon(string id, double tareKg, ComfortLevel comfort,
            int seatCapacity, int passengers, double avgBaggageKg)
        {
            var w = new PassengerWagon(id, tareKg, comfort, seatCapacity, passengers, avgBaggageKg);
            _train.AddWagon(w);
            return this;
        }

        public TrainBuilder AddRestaurantWagon(string id, double tareKg, ComfortLevel comfort,
            int diningSeats, int customers, double avgBaggageKg)
        {
            var w = new RestaurantWagon(id, tareKg, comfort, diningSeats, customers, avgBaggageKg);
            _train.AddWagon(w);
            return this;
        }

        public TrainBuilder AddMailWagon(string id, double tareKg, ComfortLevel comfort,
            double mailKg, int containers)
        {
            var w = new MailWagon(id, tareKg, comfort, mailKg, containers);
            _train.AddWagon(w);
            return this;
        }

        public TrainBuilder AddBaggageWagon(string id, double tareKg, ComfortLevel comfort,
            double loadedBaggageKg, double maxCapacityKg)
        {
            var w = new BaggageWagon(id, tareKg, comfort, loadedBaggageKg, maxCapacityKg);
            _train.AddWagon(w);
            return this;
        }

        public Train Build() => _train;
    }
}
