using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Shape
    {
        public List<Point> Points { get; set; } = new();

        public void AddPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
