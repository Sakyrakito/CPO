using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Control
{
    //[Serializable]
    public class PassengerTaxi : Car
    {
		private int passengerSeats;

        [XmlAttribute("PassengerSeats")]
        public int PassengerSeats
		{
			get { return passengerSeats; }
			set { if (value >= 2) passengerSeats = value; }
		}

        public PassengerTaxi(int passengerSeats, string mark, int dist)
            :base(mark, dist)
        {
            PassengerSeats = passengerSeats;
        }

        public PassengerTaxi() { }

        public override string ToString()
        {
            return "Passenger taxi: " + base.ToString() + $"number of passenger seats: {passengerSeats}";
        }
    }
}
