using System;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims_Test
{
    [TestClass]
    public class UnitTest1
    {
        public ClaimsRepo _repo = new ClaimsRepo();
        [TestInitialize]

        public void ATestMethodOfYourName()
        {
            ClaimsList majorOof = new ClaimsList(3448, "Car", "Car accident on 465", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimsList oohBurn = new ClaimsList(9723, "Home", "House fire in kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            ClaimsList seriouslyPancakes = new ClaimsList(6666, "Theft", "Stolen Pancakes", 400.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01)); //Raise his rates. Why would you file a claim for stolen pancakes over a month later?

            _repo.AddClaimToList(majorOof);
            _repo.AddClaimToList(oohBurn);
            _repo.AddClaimToList(seriouslyPancakes);
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
            ClaimsList majorFloof = new ClaimsList(3448, "Car", "Car accident on 465", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            bool wasAdded = _repo.AddClaimToList(majorFloof);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void RemoveClaimTest()
        {
            _repo.RemoveClaimFromList(6666);
            int expected = 2;
            int actual = _repo.GetList().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
