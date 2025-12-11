using Laboratory_5.Service_Layer;
using Laboratory_5.Data_Access_Layer;
using Laboratory_5.Business_Layer;

namespace UI_Forsm
{
    public partial class MainForm : Form
    {
        private IDailyMealService _service;
        private DailyRation _ration;

        public MainForm()
        {
            InitializeComponent();

            _service = new DailyMealService(
                new XmlCatalogRepository("D:\\CPO\\Laboratory_5\\Laboratory_5\\bin\\Debug\\net8.0\\products.xml"));

            LoadActivity();
            LoadCategories();
            CreateRation();
        }

        private void LoadActivity()
        {
            comboActivity.DataSource = Enum.GetValues(typeof(ActivityLevel));
        }

        private void LoadCategories()
        {
            comboCategories.Items.Clear();
            foreach (var c in _service.GetCategories())
                comboCategories.Items.Add(c);

            if (comboCategories.Items.Count > 0)
                comboCategories.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            listProducts.Items.Clear();
            if (comboCategories.SelectedItem is Category cat)
            {
                foreach (var p in cat.Products)
                    listProducts.Items.Add(p);
            }
        }

        private void CreateRation()
        {
            _ration = _service.CreateDailyRation(DateTime.Today);
            DisplayRation();
        }

        private void DisplayRation()
        {
            listMeals.Items.Clear();

            foreach (var meal in _ration.MealTimes)
            {
                listMeals.Items.Add("[" + meal.Name + "]");
                foreach (var item in meal.Items)
                {
                    listMeals.Items.Add(
                        $"{item.Product.Name} - {item.WeightGrams} г - {item.Calories:0.##} ккал"
                    );
                }
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboActivity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                var profile = new UserProfile()
                {
                    WeightKg = double.Parse(txtWeight.Text),
                    HeightCm = double.Parse(txtHeight.Text),
                    Age = int.Parse(txtAge.Text),
                    ActivityLevel = (ActivityLevel)comboActivity.SelectedItem
                };

                lblCalories.Text = "Норма: " + profile.GetDailyCaloriesRate().ToString("0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void comboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void listProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listProducts.Items.Clear();
            foreach (var p in _service.SearchProducts(txtSearch.Text))
                listProducts.Items.Add(p);
        }

        private void listMeals_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddToMeal_Click(object sender, EventArgs e)
        {
            if (listProducts.SelectedItem is not Product p)
            {
                MessageBox.Show("Выберите продукт!");
                return;
            }

            var meal = _ration.GetMealByName("Breakfast"); // можно будет сделать выбор
            _service.AddProductToMeal(_ration, meal.Name, p, 100);

            DisplayRation();
        }

        private void txtWeightUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateWeight_Click(object sender, EventArgs e)
        {
            try
            {
                string line = listMeals.SelectedItem.ToString();

                string productName = line.Split('-')[0].Trim();

                var meal = _ration.MealTimes.First(m => m.Items.Any(i => i.Product.Name == productName));
                var product = meal.Items.First(i => i.Product.Name == productName).Product;

                double newWeight = double.Parse(txtWeightUpdate.Text);

                _service.UpdateProductWeightInMeal(_ration, meal.Name, product.Id, newWeight);
                DisplayRation();
            }
            catch
            {
                MessageBox.Show("Выберите продукт из рациона!");
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string line = listMeals.SelectedItem.ToString();

                string productName = line.Split('-')[0].Trim();

                var meal = _ration.MealTimes.First(m => m.Items.Any(i => i.Product.Name == productName));
                var product = meal.Items.First(i => i.Product.Name == productName).Product;

                _service.RemoveProductFromMeal(_ration, meal.Name, product.Id);
                DisplayRation();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления!");
            }
        }

        private void btnAddMeal_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Название приёма пищи:", "Добавление");

            if (!string.IsNullOrWhiteSpace(name))
            {
                _service.AddMealTime(_ration, name);
                DisplayRation();
            }
        }

        private void btnRemoveMeal_Click(object sender, EventArgs e)
        {
            string line = listMeals.SelectedItem.ToString();
            if (!line.StartsWith("[")) return;

            string mealName = line.Replace("[", "").Replace("]", "");
            _service.RemoveMealTime(_ration, mealName);
            DisplayRation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _service.SaveCatalog();
            MessageBox.Show("Каталог сохранён.");
        }
    }
}
