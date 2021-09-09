using System.Collections.Generic;

namespace CoffeeMachine
{
    public class CoffeeMachine1
    {

        public List<double> GetTheCoinsFromChange(double dblChange)
        {
            List<double> lstCoinChange = new List<double>();
            dblChange *= 100; //make it cents
            while (dblChange != 0)
            {
                if (dblChange >= 200) { dblChange -= 200; lstCoinChange.Add(2.00); } //subtract $2.00 from dblChange
                if (dblChange >= 100 && dblChange < 200) { dblChange -= 100; lstCoinChange.Add(1.00); } //subtract $1.00 from dblChange
                if (dblChange >= 50 && dblChange < 100) { dblChange -= 50; lstCoinChange.Add(.50); } //subtract $0.50 from dblChange
                if (dblChange >= 20 && dblChange < 50) { dblChange -= 20; lstCoinChange.Add(.20); } //subtract $0.20 from dblChange
                if (dblChange >= 10 && dblChange < 20) { dblChange -= 10; lstCoinChange.Add(.10); } //subtract $0.10 from dblChange
                if (dblChange >= 05 && dblChange < 10) { dblChange -= 05; lstCoinChange.Add(.05); } //subtract $0.05 from dblChange
            }
            return lstCoinChange;
        }

        public double CalculateChange(double totalPaid, double coffeePrice)
        {
            return (totalPaid - coffeePrice);
        }


        public double GetCoinEntries(double coinEntered)
        {
            List<double> arrCoins = new List<double> { 1, 2, 5, 10, 20, 50, 100, 200 };
            //compare coins array
            if (arrCoins.Contains(coinEntered * 100))
            {
                if (coinEntered > .04) return coinEntered;
            }

            return 0;
        }

        public List<KeyValuePair<string, string>> GetAvailableCoffee(double dblCurrentAmount)
        {
            List<KeyValuePair<string, string>> coffeeAvailable = new List<KeyValuePair<string, string>>();
            switch (dblCurrentAmount)
            {
                case double n when (n >= 3.00 && n < 3.50):
                    coffeeAvailable.Add(new KeyValuePair<string, string> ("l", "(L)atte: $3.00"));
                    break;
                case double n when (n >= 3.0 && n < 4.0):
                    coffeeAvailable.Add(new KeyValuePair<string, string>("l", "(L)atte: $3.00"));
                    coffeeAvailable.Add(new KeyValuePair<string, string>("c", "(C)appuccino : $3.50"));
                    break;
                case double n when (n >= 4.00):
                    coffeeAvailable.Add(new KeyValuePair<string, string> ("l", "\t(L)atte: $3.00"));
                    coffeeAvailable.Add(new KeyValuePair<string, string>("c", "\t(C)appuccino : $3.50"));
                    coffeeAvailable.Add(new KeyValuePair<string, string>("d", "\t(D)ecaf: $4.00"));
                    break;
                default:
                    break;
            }
            return coffeeAvailable;
        }


        public double SelectCoffeeToPurchase(double dblTotalPaid, string strResult)
        {
            const double dblCappuccino = 3.50;
            const double dblLatte = 3.00;
            const double dblDecaf = 4.00;
            double dblChange = 0;
            switch (strResult.ToLower())
            {
                case "c":
                    dblChange = CalculateChange(dblTotalPaid, dblCappuccino);
                    break;
                case "l":
                    dblChange = CalculateChange(dblTotalPaid, dblLatte);
                    break;
                case "d":
                    dblChange = CalculateChange(dblTotalPaid, dblDecaf);
                    break;
                default:
                    dblChange = 0;
                    break;
            }
            return dblChange;
        }

        //Can also be converted to extension method
        internal bool ValidateCoffeeInitial(string strSelection)
        {
            List<string> coffeeInitials = new List<string> { "c", "l", "d" };
            return coffeeInitials.Contains(strSelection);
        }
    }

}
