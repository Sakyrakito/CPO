using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class MealTime : BusinessBase
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        private readonly List<MealItem> _items = new();
        public IReadOnlyCollection<MealItem> Items => _items.AsReadOnly();

        public MealTime() {}

        public MealTime(string name)
        {
            Name = name;
        }

        public MealItem AddProduct(Product product, double grams = 100)
        {
            if (product == null) 
                throw new ArgumentNullException(nameof(product));

            product.ThrowIfInvalid();

            var item = new MealItem(product, grams);
            _items.Add(item);

            return item;
        }

        public bool RemoveProduct(Guid productId)
        {
            var item = _items.FirstOrDefault(i => i.Product.Id.Equals(productId));

            if (item == null)
                return false;

            _items.Remove(item);
            return true;
        }

        public void UpdateProductWeight(Guid productId, double newWeight)
        {
            var item = _items.FirstOrDefault(i => i.Product.Id.Equals(productId));

            if (item == null)
                throw new InvalidOperationException("Product not found in meal");

            item.UpdateWeight(newWeight);
        }

        public double GetTotalCalories() => _items.Sum(i => i.Calories);

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                AddRule(nameof(Name), "Name of mealtime can't be empty");
        }

        public override string ToString()
        {
            return $"{Name} ({Items.Count} items, {GetTotalCalories():0.##} kcal)";
        }
    }
}
