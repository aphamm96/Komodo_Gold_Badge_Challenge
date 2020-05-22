using Komodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class ProgramUICafe
    {
        public readonly CafeRepo _repo = new CafeRepo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:\n" +
                    "1. Show menu\n" +
                    "2. Add an item to the menu\n" +
                    "3. Remove an item from the menu\n" +
                    "4. Show Ingredients");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        ShowMenu();
                        Console.ReadKey();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        ShowIngredients();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            List<MenuList> listOfMenu = _repo.GetList();
            foreach (MenuList edible in listOfMenu)
            {
                DisplayContent(edible);
            }
        }

        private void DisplayContent(MenuList food)
        {
            Console.WriteLine($"{food.MealNumber}: {food.MealName} - {food.MealDescription}. Price: {food.MealPrice}");
        }

        private void ShowIngredients()
        {
            Console.Clear();
            List<MenuList> listOfMenu = _repo.GetList();
            foreach (MenuList edible in listOfMenu)
            {
                DisplayIngredients(edible);
            }
        }

        private void DisplayIngredients(MenuList food)
        {
            Console.WriteLine($"{food.MealName} - {food.MealIngredients}");
        }

        private void AddMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter Meal Number:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Meal Name:");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter Description of Meal:");
            string mealDescription = Console.ReadLine();

            Console.WriteLine("Enter Price of the Meal:");
            double mealPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Ingredients");
            string mealIngredients = Console.ReadLine();


            MenuList newMenuItem = new MenuList(mealNumber, mealName, mealDescription, mealPrice, mealIngredients);

            _repo.AddMenuChoice(newMenuItem);
        }

        private void RemoveMenuItem()
        {
            Console.WriteLine("Select a menu number to remove:");
            List<MenuList> listOfMenu = _repo.GetList();
            foreach (MenuList edible in listOfMenu)
            {
                DisplayContent(edible);
            }
            int menuNumber = Convert.ToInt32(Console.ReadLine());
            _repo.FromRemoveMenuChoice(menuNumber);
        }

        private void SeedContentList()
        {
            MenuList cheeseburger = new MenuList(1, "Cheeseburger", "A burger with cheese", 3.50, "Buns, meat, cheese.");
            MenuList potatoChips = new MenuList(2, "Potato Chips", "Some chips from potatos", 1.75, "Potatos, chips, salt.");
            MenuList pizzaRolls = new MenuList(3, "Pizza Rolls", "Rolls of pizza", 2.50, "Pizza, rolls, sausage.");

            _repo.AddMenuChoice(cheeseburger);
            _repo.AddMenuChoice(potatoChips);
            _repo.AddMenuChoice(pizzaRolls);
        }
    }
}
