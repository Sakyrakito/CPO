using System;
using System.Xml.Serialization;

namespace TrainBuilderApp
{
    [XmlInclude(typeof(PassengerWagon))]
    [XmlInclude(typeof(RestaurantWagon))]
    [XmlInclude(typeof(MailWagon))]
    [XmlInclude(typeof(BaggageWagon))]
    public abstract class Wagon
    {
        public string Id { get; set; }

        public double TareWeightKg { get; set; }

        public ComfortLevel Comfort { get; set; }

        protected Wagon() { }

        protected Wagon(string id, double tareWeightKg, ComfortLevel comfort)
        {
            Id = id;
            TareWeightKg = tareWeightKg;
            Comfort = comfort;
        }

        public virtual int PassengerCount => 0;

        public virtual double BaggageWeightKg => 0.0;

        public override string ToString()
        {
            return $"{GetType().Name} [{Id}] Comfort={Comfort} Tare={TareWeightKg}kg";
        }
    }
}
