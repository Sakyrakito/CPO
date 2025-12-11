using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Control
{
    //[Serializable]
    public class CargoTaxi : Car
    {
		private int canWeight;

        [XmlAttribute("CanWeight")]
        public int CanWeight
		{
			get { return canWeight; }
			set { if (value > 0) canWeight = value; }
		}

        public CargoTaxi()
        {
            
        }

        public CargoTaxi(int canWeight, string mark, int dist)
            : base(mark, dist)
        {
            CanWeight = canWeight;
        }

        public override string ToString()
        {
            return "Cargo taxi: " + base.ToString() + $"can weight: {canWeight}";
        }
    }
}
