using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo
{
    public class CafeRepo
    {
        private List<MenuList> _menuContents = new List<MenuList>();
        public bool AddMenuChoice(MenuList food)
        {
            int startingCount = _menuContents.Count;
            _menuContents.Add(food);
            bool wasAdded = _menuContents.Count == startingCount + 1;
            return wasAdded;
        }

        public List<MenuList> GetList()
        {
            return _menuContents;
        }

        public MenuList GetListByNumber(int mealNumber)
        {
            foreach (MenuList foodItem in _menuContents)
            {
                if(foodItem.MealNumber == mealNumber)
                {
                    return foodItem;
                }
            }
            return null;
        }

        public bool ToRemoveMenuChoice(MenuList food)
        {
            int startingCount = _menuContents.Count;
            _menuContents.Remove(food);
            bool wasRemoved = _menuContents.Count == startingCount - 1;
            return wasRemoved;
        }
        public bool FromRemoveMenuChoice(int menuNumber)
        {
            MenuList removal = GetListByNumber(menuNumber);

            if (removal == null)
            {
                Console.WriteLine("That cannot be done.");
                return false;
            }

            else
            {

                //int index = _menuContents.IndexOf(removal);
                _menuContents.Remove(removal);
                return true;
            }

        }
    }
}
