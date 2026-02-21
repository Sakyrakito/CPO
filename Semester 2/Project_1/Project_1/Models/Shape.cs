using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Shape
    {
        public List<Polygon> Polygons { get; set; } = new();

        public void AddPolygon(Polygon polygon)
        {
            Polygons.Add(polygon);
        }
    }
}
