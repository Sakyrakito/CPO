using System;

namespace TrainBuilderApp
{
    public class MailWagon : Wagon
    {
        public double MailWeightKg { get; set; }

        public int Containers { get; set; }

        public MailWagon() { }

        public MailWagon(string id, double tareKg, ComfortLevel comfort,
            double mailWeightKg, int containers)
            : base(id, tareKg, comfort)
        {
            MailWeightKg = mailWeightKg;
            Containers = containers;
        }

        public override double BaggageWeightKg => MailWeightKg;

        public override string ToString()
        {
            return $"{base.ToString()} MailWeight={MailWeightKg}kg Containers={Containers}";
        }
    }
}
