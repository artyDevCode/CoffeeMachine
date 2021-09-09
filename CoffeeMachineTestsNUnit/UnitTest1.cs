using NUnit.Framework;
using CoffeeMachine;
using System.Collections.Generic;
using System;

namespace CoffeeMachineTestsNUnit
{
    public class Tests
    {
        private CoffeeMachine1 _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new CoffeeMachine1();
        }

        [Test]
        public void GetTheCoinsFromChange_ShouldDisplayCorrectCoins()
        {
            double change = 3.70; 
            List<double> expected = new List<double> { 1.00, 2.00, 0.50, 0.20 };

            var res = _sut.GetTheCoinsFromChange(change);

            Assert.AreEqual(4, res.Count);

            foreach (var item in res)
            {
                Assert.IsTrue(expected.Contains(item));
            }
        }

        [Test]
        public void CalculateChange_ShouldDisplayCorrectChange()
        {
            double totalPaid = 3.70;
            double coffeePrice = 3.50;

            var res = _sut.CalculateChange(totalPaid, coffeePrice);

            Assert.AreEqual(.20, Math.Round((Double)res, 2));
        }

        [Test]
        public void CalculateChange_ShouldNotDisplayCorrectChange()
        {
            double totalPaid = 3.70;
            double coffeePrice = 3.50;

            var res = _sut.CalculateChange(totalPaid, coffeePrice);

            Assert.AreNotEqual(.50, res);
        }

        [Test]
        public void SelectCoffeeToPurchase_ShouldDisplayuCorrectCoffee()
        {
            double dblTotalPaid = 4;
            string strResult = "c";

            var res = _sut.SelectCoffeeToPurchase(dblTotalPaid, strResult);

            Assert.AreEqual(.50, res);
        }

        [Test]
        public void GetCoinEntries_ShouldDisplayCorrectCoins()
        {
            List<double> arrCoins = new List<double> { 1, 2, 5, 10, 20, 50, 100, 200 };
            double coinEntered = .20;

            var res = _sut.GetCoinEntries(coinEntered);

            Assert.Greater(coinEntered, .04);
            Assert.IsTrue(arrCoins.Contains(coinEntered * 100));
        }

        [Test]
        public void GetAvailableCoffee_ShouldDisplayAvailableCoffeeFromAmaount()
        {
            double dblCurrentAmount = 3.70;
            List<KeyValuePair<string, string>> coffeeAvailable = new List<KeyValuePair<string, string>>();
            coffeeAvailable.Add(new KeyValuePair<string, string>("l", "(L)atte: $3.00"));
            coffeeAvailable.Add(new KeyValuePair<string, string>("c", "(C)appuccino : $3.50"));

            var res = _sut.GetAvailableCoffee(dblCurrentAmount);

            Assert.AreEqual(coffeeAvailable, res);
        }

        [Test]
        public void ValidateCoinEntry_ShouldPassCoinValue()
        {
            string coin = ".20";
            var res = coin.ValidateCoinEntry();
            Assert.IsTrue(res);
        }

        [Test]
        public void ValidateCoinEntry_ShouldNotPassCoinValueAlpha()
        {
            string coin = "a";
            var res = coin.ValidateCoinEntry();
            Assert.IsFalse(res);
        }
        [Test]
        public void ValidateCoinEntry_ShouldNotPassCoinValueZero()
        {
            string coin = "0";
            var res = coin.ValidateCoinEntry();
            Assert.IsFalse(res);
        }
    }
}