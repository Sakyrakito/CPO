using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class Category : BusinessBase
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        private readonly List<Product> _products = new();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category() {}

        public Category(string name)
        {
            Name = name;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            product.ThrowIfInvalid();

            //if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            //    throw new InvalidOperationException($"Product with name {product.Name} already exist in this categoty");

            _products.Add(product);
        }

        public bool RemoveProduct(Guid productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                AddRule(nameof(Name), "Name of category can't be empty");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
