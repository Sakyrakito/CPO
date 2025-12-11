using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class MealPlanService : IMealPlanServices
    {
        private readonly Dictionary<DateTime, DailyRation> _store = new();

        public void AddMealTime(DailyRation ration, string mealName)
        {
            if (ration == null) 
                throw new ArgumentNullException(nameof(ration));

            var meal = new MealTime(mealName);
            ration.AddMealTime(meal);
        }

        public MealItem AddProductToMeal(DailyRation ration, string mealName, Product product, double grams = 100)
        {
            if (ration == null)
                throw new ArgumentNullException(nameof(ration));

            var meal = ration.GetMealByName(mealName) ?? throw new InvalidOperationException("Meal time not found");

            return meal.AddProduct(product, grams);
        }

        public DailyRation CreateDailyRation(DateTime date)
        {
            var key = date.Date;

            //if (_store.ContainsKey(key))
            //    throw new InvalidOperationException("Daily ration for day already exist.");

            var ration = new DailyRation(key);
            _store[key] = ration;

            return ration;
        }

        public double GetDailyCalories(DailyRation ratio)
        {
            if (ratio == null)
                throw new ArgumentNullException(nameof(ratio));

            return ratio.GetDailyCalories();
        }

        public DailyRation GetDailyRation(DateTime date)
        {
            _store.TryGetValue(date.Date, out var ration);
            return ration;
        }

        public void RemoveMealTime(DailyRation ration, string mealName)
        {
            if (ration == null)
                throw new ArgumentNullException(nameof(ration));

            if (!ration.RemoveMealTime(mealName))
                throw new InvalidOperationException("Meal time not found");
        }

        public bool RemoveProductFromMeal(DailyRation ration, string mealName, Guid productId)
        {
            if (ration == null)
                throw new ArgumentNullException(nameof(ration));

            var meal = ration.GetMealByName(mealName) ?? throw new InvalidOperationException("Meal time not found");

            return meal.RemoveProduct(productId);
        }

        public void UpdateProductWeightInMeal(DailyRation ration, string mealName, Guid productId, double newGrams)
        {
            if (ration == null)
                throw new ArgumentNullException(nameof(ration));

            var meal = ration.GetMealByName(mealName) ?? throw new InvalidOperationException("Meal time not found");

            meal.UpdateProductWeight(productId, newGrams);
        }
    }
}
