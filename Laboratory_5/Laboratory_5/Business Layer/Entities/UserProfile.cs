using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class UserProfile : BusinessBase
    {
        public double WeightKg { get; set; }
        public double HeightCm { get; set; }
        public int Age { get; set; }
        public ActivityLevel ActivityLevel { get; set; } = ActivityLevel.Normal;

        public double GetBMR()
        {
            return 447.593 + 9.247 * WeightKg + 3.098 * HeightCm - 4.330 * Age;
        }

        public double GetARM()
        {
            return ActivityLevel switch
            {
                ActivityLevel.Low => 1.2,
                ActivityLevel.Normal => 1.375,
                ActivityLevel.Average => 1.55,
                ActivityLevel.High => 1.725,
                _ => 1.375
            };
        }

        public double GetDailyCaloriesRate()
        {
            var bmr = GetBMR();
            var arm = GetARM();
            return bmr + arm;
        }

        public override void Validate()
        {
            if (WeightKg <= 0 || WeightKg > 500)
                AddRule(nameof(WeightKg), "Weight must be normal");

            if (HeightCm <= 0 || HeightCm > 300)
                AddRule(nameof(HeightCm), "Height must be normal");

            if (Age <= 0 || Age > 130)
                AddRule(nameof(Age), "Age must be normal");
        }

        public override string ToString()
        {
            return $"User: {WeightKg} kg, {HeightCm} cm, {Age} y, Activity = {ActivityLevel}";
        }
    }
}
