using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboratory_5.Data_Access_Layer
{
    public class CategoryXml
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("description")]   
        public string Description { get; set; }

        [XmlElement("Product")]
        public List<ProductXml> Products { get; set; } = new();
    }
}
