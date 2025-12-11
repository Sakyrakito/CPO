using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class MealItem
    {
        public Product Product { get; }
        public double WeightGrams { get; private set; }

        public MealItem(Product product, double weightGrams)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            
            if (weightGrams <= 0)
                throw new ArgumentOutOfRangeException(nameof(weightGrams));
            
            WeightGrams = weightGrams;
        }

        public void UpdateWeight(double newWeight)
        {
            if (newWeight <= 0)
                throw new ArgumentOutOfRangeException(nameof(newWeight));

            WeightGrams = newWeight;
        }

        public double Calories => Product.GetCalories(WeightGrams);
    }
}
