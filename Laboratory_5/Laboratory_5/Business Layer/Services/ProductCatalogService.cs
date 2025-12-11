using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly List<Category> _categories = new();
        public IReadOnlyCollection<Category> GetAllCategories() => _categories.AsReadOnly();

        public void AddProductToCategory(Guid categoryId, Product product)
        {
            var category = GetCategory(categoryId) ?? throw new InvalidOperationException("Category not found");

            product.ThrowIfInvalid();
            category.AddProduct(product);
        }

        public Category CreateCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Name required", nameof(categoryName));

            //if (_categories.Any(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
            //    throw new InvalidOperationException($"Category with name {categoryName} already exist");

            var category = new Category(categoryName);
            category.ThrowIfInvalid();
            _categories.Add(category);

            return category;
        }

        public Category? GetCategory(Guid categoryId)
        {
            return _categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public bool RemoveCategory(Guid categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
                return false;

            _categories.Remove(category);
            return true;
        }

        public bool RemoveProductFromCategory(Guid categoryId, Guid productId)
        {
            var category = GetCategory(categoryId) ?? throw new InvalidOperationException("Category not found");
            
            return category.RemoveProduct(productId);
        }

        public IReadOnlyCollection<Product> SearchProduct(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return _categories.SelectMany(c => c.Products).ToList().AsReadOnly();

            var q = search.Trim();
            var result = _categories
                .SelectMany(c => c.Products)
                .Where(p => p.Name.Contains(q, StringComparison.OrdinalIgnoreCase))
                .ToList()
                .AsReadOnly();

            return result;
        }
    }
}
