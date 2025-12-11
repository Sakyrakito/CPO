using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Control
{
	[XmlInclude(typeof(CargoTaxi))]
	[XmlInclude(typeof(PassengerTaxi))]
    //[Serializable]
    public abstract class Car
	{
		private string mark;

		[XmlAttribute("Mark")]
		public string Mark
		{
			get { return mark; }
			set { if (value != string.Empty) mark = value; }
		}

		private int dist;

        [XmlAttribute("Dist")]
        public int Dist
		{
			get { return dist; }
			set { if (value >= 0) dist = value; }
		}

		public Car(string mark, int dist)
		{
			Mark = mark;
			Dist = dist;
		}

		public Car() { }

        public override string ToString()
        {
			return $"Mark: {mark}, dist: {dist} ";
        }
    }

    public class CompareByDist : IComparer<Car>
    {
        public int Compare(Car? x, Car? y)
        {
			return x.Dist.CompareTo(y.Dist);
        }
    }
}
