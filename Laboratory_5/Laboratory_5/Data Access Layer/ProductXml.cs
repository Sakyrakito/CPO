using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboratory_5.Data_Access_Layer
{
    public class ProductXml
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Gramms")]
        public string Gramms { get; set; }

        [XmlElement("Protein")]
        public string Protein { get; set; }

        [XmlElement("Fats")]
        public string Fats { get; set; }

        [XmlElement("Carbs")]
        public string Carbs { get; set; }

        [XmlElement("Calories")]
        public string Calories { get; set; }
    }
}
