using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class Product : BusinessBase
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double CaloriesPer100g { get; set; }

        public Product() { }

        public Product(string name, double proteins, double fats, double carbs, double caloriesPer100g)
        {
            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbs = carbs;
            CaloriesPer100g = caloriesPer100g;
        }

        public double GetCalories(double weightGrams)
        {
            if (weightGrams < 0)
                throw new ArgumentOutOfRangeException(nameof(weightGrams));

            return CaloriesPer100g * weightGrams / 100.0;
        }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                AddRule(nameof(Name), "Must not be empty.");

            if (Proteins < 0 || Proteins > 100)
                AddRule(nameof(Proteins), "Must be in [1; 100]");

            if (Fats < 0 || Fats > 100)
                AddRule(nameof(Fats), "Must be in [1; 100]");

            if (Carbs < 0 || Carbs > 100)
                AddRule(nameof(Carbs), "Must be in [1; 100]");

            if (CaloriesPer100g < 0)
                AddRule(nameof(CaloriesPer100g), "Must be non-negative");
        }

        public override string ToString()
        {
            return $"{Name} ({CaloriesPer100g} kcal/100g)";
        }
    }
}
