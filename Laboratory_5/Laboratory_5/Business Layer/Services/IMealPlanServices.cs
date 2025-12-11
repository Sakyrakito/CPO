using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public interface IMealPlanServices
    {
        DailyRation CreateDailyRation(DateTime date);
        DailyRation GetDailyRation(DateTime date);
        void AddMealTime(DailyRation ration, string mealName);
        void RemoveMealTime(DailyRation ration, string mealName);
        MealItem AddProductToMeal(DailyRation ration, string mealName, Product product, double grams = 100);
        bool RemoveProductFromMeal(DailyRation ration, string mealName, Guid productId);
        void UpdateProductWeightInMeal(DailyRation ration, string mealName, Guid productId, double newGrams);
        double GetDailyCalories(DailyRation ratio);
    }
}
