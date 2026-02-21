using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class State
    {
        public string StateCode { get; set; } = string.Empty;
        public List<Shape> Shapes { get; set; } = new();

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }
    }
}
