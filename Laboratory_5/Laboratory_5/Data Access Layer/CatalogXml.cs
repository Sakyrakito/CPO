using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboratory_5.Data_Access_Layer
{
    [XmlRoot("root")]
    public class CatalogXml
    {
        [XmlElement("Category")]
        public List<CategoryXml> Categories { get; set; } = new();
    }
}
