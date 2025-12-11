using Laboratory_5.Business_Layer;
using Laboratory_5.Data_Access_Layer;
using Laboratory_5.Service_Layer;
using System;

namespace Laboratory_5
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IDailyMealService service = new DailyMealService(
                new XmlCatalogRepository("products.xml"));

        }
    }
}
