using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public interface IProductCatalogService
    {
        IReadOnlyCollection<Category> GetAllCategories();
        Category CreateCategory(string categoryName);
        bool RemoveCategory(Guid categoryId);
        Category GetCategory(Guid categoryId);
        void AddProductToCategory(Guid categoryId, Product product);
        bool RemoveProductFromCategory(Guid categoryId, Guid productId);
        IReadOnlyCollection<Product> SearchProduct(string search);
    }
}
