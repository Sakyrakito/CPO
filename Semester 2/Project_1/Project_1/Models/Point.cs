using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Point
    {
        public double Longtitude { get; set; }
        public double Latitude { get; set; }

        public Point(double _Longtitude, double _Latitude)
        {
            Longtitude = _Longtitude;
            Latitude = _Latitude;
        }

        public override string ToString()
        {
            return $"Lon: {Longtitude}, Lat: {Latitude}";
        }
    }
}
