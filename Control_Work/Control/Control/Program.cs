using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Control
{
    class Program
    {
        private static XmlSerializer serializer = new XmlSerializer(typeof(TaxiPark));

        static void Main(string[] args)
        {
            TaxiPark taxiPark = new TaxiPark();
            try
            {
                using (var reader = new StreamReader("TaxiPark.xml"))
                {
                    taxiPark = (TaxiPark)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Taxi park:");
            Console.WriteLine(taxiPark);

            taxiPark.Add(new CargoTaxi(4, "BMW", 14));
            taxiPark.Add(new PassengerTaxi(4, "Audi", 120));

            if (!taxiPark.IsBigCargo())
            {
                taxiPark.Add(new CargoTaxi(6, "Ford", 0));
            }

            taxiPark.Sort(new CompareByDist());

            Console.WriteLine("Sorted taxi park:");
            Console.WriteLine(taxiPark);

            TaxiPark passegerTaxis = taxiPark.GetPassegerTaxiWhith5MoreSeats();

            if (passegerTaxis.IsEmpty())
            {
                Console.WriteLine("There is no passenger taxis whith more than 5 seats");
            }
            else
            {
                Console.WriteLine(passegerTaxis);
            }

            try
            {
                using (var writer = new StreamWriter("TaxiPark.xml"))
                {
                    serializer.Serialize(writer, taxiPark);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}