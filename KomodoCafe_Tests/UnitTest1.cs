using System;
using Komodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class RepoTests
    {
        private CafeRepo _repo = new CafeRepo();
        [TestInitialize]
        public void SeedTheRepo()
        {
            MenuList cheeseburger = new MenuList(1, "Cheeseburger", "A burger with cheese", 3.50, "Buns, meat, cheese.");
            MenuList potatoChips = new MenuList(2, "Potato Chips", "Some chips from potatos", 1.75, "Potatos, chips, salt.");
            MenuList pizzaRolls = new MenuList(3, "Pizza Rolls", "Rolls of pizza", 2.50, "Pizza, rolls, sausage.");

            _repo.AddMenuChoice(cheeseburger);
            _repo.AddMenuChoice(potatoChips);
            _repo.AddMenuChoice(pizzaRolls);
        }
        [TestMethod]
        public void TestAddContentToMenu()
        {

            int expected = 3;
            int actual = _repo.GetList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddContentManually()
        {
            MenuList pumpkin = new MenuList(1, "Cheeseburger", "A burger with cheese", 3.50, "Buns, meat, cheese.");
            bool wasAdded = _repo.AddMenuChoice(pumpkin);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void RemoveContentTest()
        {
            _repo.FromRemoveMenuChoice(1);
            int expected = 2;
            int actual = _repo.GetList().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
