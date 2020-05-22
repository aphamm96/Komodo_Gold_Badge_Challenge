using System;
using System.Collections.Generic;
using KomodoBadge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBadge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly BadgeRepo _badgeTests = new BadgeRepo();
        [TestInitialize]
        public void AMethodByAnyOtherName()
        {
            _badgeTests.SeedContent();
        }

        [TestMethod]
        public void TestAddContentToBadgeList()
        {

            int expected = 3;
            int actual = _badgeTests.GetList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddContentManually()
        {
            bool wasAdded = _badgeTests.AddBadgeToList(7777, new List<string>() { "A1" });


            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void AddDoorTest() //Badge 12345 should have 2 badges now
        {
            List<string> doors = _badgeTests.GetBadgeByNumber(12345);
            string doorAdd = "F4";
            doors.Add(doorAdd);
            _badgeTests.UpdateBadgeList(12345, doors);

            int actual = _badgeTests.GetBadgeByNumber(12345).Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveDoorTest() //Badge 12345 should have 0 badges now
        {
            List<string> doors = _badgeTests.GetBadgeByNumber(12345);
            string doorRemove = "A1";
            doors.Remove(doorRemove);
            _badgeTests.UpdateBadgeList(12345, doors);

            int actual = _badgeTests.GetBadgeByNumber(12345).Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
