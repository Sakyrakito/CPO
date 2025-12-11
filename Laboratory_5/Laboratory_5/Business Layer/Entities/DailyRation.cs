using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class DailyRation : BusinessBase
    {
        public DateTime Date { get; set; }

        private readonly List<MealTime> _mealTimes = new();
        public IReadOnlyCollection<MealTime> MealTimes => _mealTimes.AsReadOnly();

        public DailyRation()
        {
            Date = DateTime.Now;
            EnsureDefaultMealTime();
        }

        public DailyRation(DateTime date)
        {
            Date = date;
            EnsureDefaultMealTime();
        }

        private void EnsureDefaultMealTime()
        {
            if (!_mealTimes.Any())
            {
                _mealTimes.Add(new MealTime("Breakfast"));
                _mealTimes.Add(new MealTime("Lunch"));
                _mealTimes.Add(new MealTime("Dinner"));
            }
        }

        public MealTime? GetMealByName(string name)
        {
            return _mealTimes.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddMealTime(MealTime mealTime)
        {
            if (mealTime == null)
                throw new ArgumentNullException(nameof(mealTime));

            //if (_mealTimes.Any(m => m.Name.Equals(mealTime.Name, StringComparison.OrdinalIgnoreCase)))
            //    throw new InvalidOperationException($"Meal time with name {mealTime.Name} already exist");

            _mealTimes.Add(mealTime);
        }

        public bool RemoveMealTime(string name)
        {
            var mealTime = GetMealByName(name);

            if (mealTime == null)
                return false;

            _mealTimes.Remove(mealTime);
            return true;
        }

        public double GetDailyCalories() => _mealTimes.Sum(m => m.GetTotalCalories());

        public override void Validate()
        {
            if (Date == default)
                AddRule(nameof(Date), "Date required");

            if (!_mealTimes.Any())
                AddRule(nameof(MealTimes), "Requireds at least 1 meal time");
        }

        public override string ToString()
        {
            return $"Daily ration {Date:DD-MM-yyyy} - {GetDailyCalories():0.##} kcal";
        }
    }
}
