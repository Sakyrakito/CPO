using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Polygon
    {
        public List<Point> points { get; set; } = new();

        public void AddPoint(Point point)
        {
            points.Add(point);
        }
    }
}
