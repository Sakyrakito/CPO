using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Control
{
    [XmlRoot("TaxiPark")]
    //[Serializable]
    public class TaxiPark
    {
        [XmlElement("CargoTaxi", Type = typeof(CargoTaxi))]
        [XmlElement("PassengerTaxi", Type = typeof(PassengerTaxi))]
        public List<Car> cars = new List<Car>();

        public TaxiPark() {}
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public bool IsBigCargo()
        {
            foreach (Car car in cars)
            {
                if (car is CargoTaxi cargoTaxi && cargoTaxi.CanWeight > 5)
                {
                    return true;
                }
            }

            return false;
        }

        public int MyProperty
        {
            get 
            {
                int summaryDist = 0;
                foreach (Car car in cars)
                {
                    summaryDist += car.Dist;
                }

                return summaryDist;
            }
        }

        public void Sort(IComparer<Car> comparer)
        {
            cars.Sort(comparer);
        }

        public bool IsEmpty()
        {
            return cars.Count == 0;
        }

        public TaxiPark GetPassegerTaxiWhith5MoreSeats()
        {
            TaxiPark result = new TaxiPark();

            foreach (Car car in cars)
            {
                if (car is PassengerTaxi passengerTaxi && passengerTaxi.PassengerSeats > 5)
                {
                    result.Add(car);
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            foreach (Car car in cars)
            {
                info.Append(car.ToString() + "\n");
            }

            return info.ToString();
        }
    }
}
