using Laboratory_5.Business_Layer;
using Laboratory_5.Data_Access_Layer;

namespace Laboratory_5.Service_Layer
{
    public class DailyMealService : IDailyMealService
    {
        private readonly IXmlCatalogRepository _repository;
        private readonly ProductCatalogService _catalogService;
        private readonly MealPlanService _mealService;

        public DailyMealService(IXmlCatalogRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            var categories = _repository.LoadCatalog();
            _catalogService = new ProductCatalogService();

            foreach (var c in categories)
            {
                var newCategory = _catalogService.CreateCategory(c.Name);

                foreach (var p in c.Products)
                    _catalogService.AddProductToCategory(newCategory.Id, p);
            }

            _mealService = new MealPlanService();
        }

        // Categories

        public IReadOnlyCollection<Category> GetCategories()
            => _catalogService.GetAllCategories();

        public Category CreateCategory(string name)
            => _catalogService.CreateCategory(name);

        public bool RemoveCategory(Guid categoryId)
            => _catalogService.RemoveCategory(categoryId);

        public Category GetCategory(Guid categoryId)
            => _catalogService.GetCategory(categoryId);

        // Products

        public IReadOnlyCollection<Product> GetProducts(string categoryName)
        {
            var cat = _catalogService.GetAllCategories()
                .FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            return cat?.Products ?? Array.Empty<Product>();
        }

        public void AddProductToCategory(Guid categoryId, Product product)
            => _catalogService.AddProductToCategory(categoryId, product);

        public bool RemoveProductFromCategory(Guid categoryId, Guid productId)
            => _catalogService.RemoveProductFromCategory(categoryId, productId);

        public IReadOnlyCollection<Product> SearchProducts(string search)
            => _catalogService.SearchProduct(search);

        // Ration

        public DailyRation CreateDailyRation(DateTime date)
            => _mealService.CreateDailyRation(date);

        public DailyRation GetDailyRation(DateTime date)
            => _mealService.GetDailyRation(date);

        public MealItem AddProductToMeal(DailyRation ration, string mealName, Product product, double grams)
            => _mealService.AddProductToMeal(ration, mealName, product, grams);

        public bool RemoveProductFromMeal(DailyRation ration, string mealName, Guid productId)
            => _mealService.RemoveProductFromMeal(ration, mealName, productId);

        public void UpdateProductWeightInMeal(DailyRation ration, string mealName, Guid productId, double newGrams)
            => _mealService.UpdateProductWeightInMeal(ration, mealName, productId, newGrams);

        public double GetDailyRationCalories(DailyRation ration)
            => _mealService.GetDailyCalories(ration);

        public void AddMealTime(DailyRation ration, string mealName)
            => _mealService.AddMealTime(ration, mealName);

        public void RemoveMealTime(DailyRation ration, string mealName)
            => _mealService.RemoveMealTime(ration, mealName);

        // XML

        public void SaveCatalog()
        {
            var categories = _catalogService.GetAllCategories().ToList();
            _repository.SaveCatalog(categories);
        }
    }
}
