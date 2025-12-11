using Laboratory_5.Business_Layer;
using Laboratory_5.Data_Access_Layer;
using Laboratory_5.Service_Layer;
using System;

namespace Laboratory_5
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IDailyMealService service = new DailyMealService(
                new XmlCatalogRepository("products.xml"));

            Console.WriteLine("=== TEST 1: Загруженные категории ===");
            foreach (var c in service.GetCategories())
                Console.WriteLine("Категория: " + c.Name);

            // ====== TEST 2: Создание категории ======
            Console.WriteLine("\n=== TEST 2: Создание новой категории \"Овощи\" ===");
            var veg = service.CreateCategory("Овощи");
            Console.WriteLine("Создана категория: " + veg.Name);

            // ====== TEST 3: Добавление продуктов ======
            Console.WriteLine("\n=== TEST 3: Добавление продуктов в категорию \"Овощи\" ===");
            var carrot = new Product("Морковь", 1.3, 0.1, 6.9, 32);
            service.AddProductToCategory(veg.Id, carrot);
            Console.WriteLine("Добавлен продукт: " + carrot.Name);

            var cucumber = new Product("Огурец", 0.7, 0.1, 3.6, 15);
            service.AddProductToCategory(veg.Id, cucumber);
            Console.WriteLine("Добавлен продукт: " + cucumber.Name);

            // ====== TEST 4: Получение продуктов в категории ======
            Console.WriteLine("\n=== TEST 4: Все продукты в \"Овощи\" ===");
            foreach (var p in service.GetProducts("Овощи"))
                Console.WriteLine(" - " + p.Name + $" ({p.CaloriesPer100g} kcal/100g)");

            // ====== TEST 5: Поиск продуктов ======
            Console.WriteLine("\n=== TEST 5: Поиск продуктов по фрагменту 'ог' ===");
            var found = service.SearchProducts("ог");
            foreach (var p in found)
                Console.WriteLine("Найдено: " + p.Name);

            // ====== TEST 6: Создание дневного рациона ======
            Console.WriteLine("\n=== TEST 6: Создание дневного рациона ===");
            var ration = service.CreateDailyRation(DateTime.Today);
            Console.WriteLine("Рацион создан: " + ration.Date.ToShortDateString());

            // ====== TEST 7: Добавление продуктов в рацион ======
            Console.WriteLine("\n=== TEST 7: Добавление продуктов в приёмы пищи ===");

            service.AddProductToMeal(ration, "Breakfast", carrot, 120);
            service.AddProductToMeal(ration, "Breakfast", cucumber, 100);
            Console.WriteLine("Добавлены продукты в Breakfast");

            // ====== TEST 8: Обновление веса продукта в приёме пищи ======
            Console.WriteLine("\n=== TEST 8: Обновление веса продукта ===");
            var carrotItem = ration.GetMealByName("Breakfast")?
                .Items.First(i => i.Product.Name == "Морковь");

            if (carrotItem != null)
            {
                service.UpdateProductWeightInMeal(ration, "Breakfast", carrotItem.Product.Id, 200);
                Console.WriteLine("Вес продукта 'Морковь' обновлён до 200 г");
            }

            // ====== TEST 9: Подсчёт калорий ======
            Console.WriteLine("\n=== TEST 9: Подсчёт калорий ===");
            double kcal = service.GetDailyRationCalories(ration);
            Console.WriteLine("Итоговая калорийность дня: " + kcal + " kcal");

            // ====== TEST 10: Удаление продукта из приёма пищи ======
            Console.WriteLine("\n=== TEST 10: Удаление продукта из Breakfast ===");
            service.RemoveProductFromMeal(ration, "Breakfast", cucumber.Id);
            Console.WriteLine("Огурец удалён");

            // ====== TEST 11: Добавление нового приёма пищи ======
            Console.WriteLine("\n=== TEST 11: Добавление приёма пищи 'Snack' ===");
            service.AddMealTime(ration, "Snack");
            Console.WriteLine("Snack добавлен");

            // ====== TEST 12: Удаление приёма пищи ======
            Console.WriteLine("\n=== TEST 12: Удаление 'Snack' ===");
            service.RemoveMealTime(ration, "Snack");
            Console.WriteLine("Snack удалён");

            // ====== TEST 13: Сохранение каталога ======
            Console.WriteLine("\n=== TEST 13: Сохранение каталога в XML ===");
            service.SaveCatalog();
            Console.WriteLine("Каталог сохранён в products.xml");

            Console.WriteLine("\n=== ВСЕ ТЕСТЫ ПРОЙДЕНЫ ===");
        }
    }
}
