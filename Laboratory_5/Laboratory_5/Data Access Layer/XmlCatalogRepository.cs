using Laboratory_5.Business_Layer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboratory_5.Data_Access_Layer
{
    public class XmlCatalogRepository : IXmlCatalogRepository
    {
        private string _filePath;

        public XmlCatalogRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("file path required");

            _filePath = filePath;
        }

        public List<Category> LoadCatalog()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("XML file not found", _filePath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CatalogXml));

            CatalogXml catalog;

            using (var reader = new StreamReader(_filePath))
            {
                catalog = xmlSerializer.Deserialize(reader) as CatalogXml;
            }

            if (catalog == null)
                throw new Exception("Invalid XML format");

            return catalog.Categories.Select(MapToBusinessCategory).ToList();
        }

        public void SaveCatalog(List<Category> categories)
        {
            if (categories == null)
                throw new ArgumentNullException(nameof(categories));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CatalogXml));

            var root = new CatalogXml
            {
                Categories = categories.Select(MapToXmlCategory).ToList()
            };

            using (var writer = new StreamWriter(_filePath))
            {
                xmlSerializer.Serialize(writer, root);
            }
        }

        private Category MapToBusinessCategory(CategoryXml xml)
        {
            var category = new Category(xml.Name);

            foreach (var p in xml.Products)
            {
                double protein = ParseDouble(p.Protein);
                double fats = ParseDouble(p.Fats);
                double carbs = ParseDouble(p.Carbs);
                double calories = ParseDouble(p.Calories);

                var product = new Product(p.Name, protein, fats, carbs, calories);

                product.ThrowIfInvalid();
                category.AddProduct(product);
            }

            category.ThrowIfInvalid();
            return category;
        }

        private CategoryXml MapToXmlCategory(Category category)
        {
            return new CategoryXml
            {
                Name = category.Name,
                Description = "",
                Products = category.Products.Select(MapToXmlProduct).ToList()
            };
        }

        private ProductXml MapToXmlProduct(Product product)
        {
            return new ProductXml
            {
                Name = product.Name,
                Gramms = "100",
                Protein = product.Proteins.ToString(CultureInfo.InvariantCulture),
                Fats = product.Fats.ToString(CultureInfo.InvariantCulture),
                Carbs = product.Carbs.ToString(CultureInfo.InvariantCulture),
                Calories = product.CaloriesPer100g.ToString(CultureInfo.InvariantCulture)
            };
        }

        private double ParseDouble(string s)
        {
            return double.Parse(s.Replace(",", "."), CultureInfo.InvariantCulture);
        }
    }
}
