using Laboratory_5.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Service_Layer
{
    public interface IDailyMealService
    {
        // ===== Категории =====
        IReadOnlyCollection<Category> GetCategories();
        Category CreateCategory(string name);
        bool RemoveCategory(Guid categoryId);
        Category GetCategory(Guid categoryId);

        // ===== Продукты =====
        IReadOnlyCollection<Product> GetProducts(string categoryName);
        void AddProductToCategory(Guid categoryId, Product product);
        bool RemoveProductFromCategory(Guid categoryId, Guid productId);
        IReadOnlyCollection<Product> SearchProducts(string search);

        // ===== Работа с рационом =====
        DailyRation CreateDailyRation(DateTime date);
        DailyRation GetDailyRation(DateTime date);
        MealItem AddProductToMeal(DailyRation ration, string mealName, Product product, double grams);
        bool RemoveProductFromMeal(DailyRation ration, string mealName, Guid productId);
        void UpdateProductWeightInMeal(DailyRation ration, string mealName, Guid productId, double newGrams);
        double GetDailyRationCalories(DailyRation ration);
        void AddMealTime(DailyRation ration, string mealName);
        void RemoveMealTime(DailyRation ration, string mealName);

        // ===== Сохранение =====
        void SaveCatalog();
    }
}
