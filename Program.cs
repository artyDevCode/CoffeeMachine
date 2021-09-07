using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //array of valid coins
            double[] arrCoins = { 1, 2, 5, 10, 20, 50, 100, 200 };

            //display coffee available and price of each coffee
            Console.WriteLine("Coffee types available");
            Console.WriteLine("\t(C)appuccino : $3.50");
            Console.WriteLine("\t(L)atte: $3.00");
            Console.WriteLine("\t(D)ecaf: $4.00");

            Console.WriteLine("Enter your payment amount (in coins only): ie 20 Cents = .20, $2 coin = 2");
            Console.WriteLine("Press 0 when finished entering coins");
            double dblTotalPaid = 0.00; //sum coin value 
            double dblPaymentFlag = -1; //coins payment amount
            while (dblPaymentFlag != 0)
            {
                //check is its a valid numeric entry
                if (!double.TryParse(Console.ReadLine(), out dblPaymentFlag))
                {
                    Console.Write("This is not a valid coin value, please try again\n");
                    dblPaymentFlag = -1; //reset the payment to -1
                }
                //compare coins array
                if (arrCoins.Contains(dblPaymentFlag * 100))
                {
                    if (dblPaymentFlag > .04) dblTotalPaid += dblPaymentFlag;
                }
                else if (dblPaymentFlag != 0) Console.Write("Please enter valid coins\n");
            };

            Console.WriteLine($"Coffee available for purchase with ${dblTotalPaid.ToString($"0.##")}: ");
            switch (dblTotalPaid)
            {
                case double n when (n >= 3.00 && n < 3.50):
                    Console.WriteLine("\t(L)atte: $3.00");
                    DisplayPurchase(dblTotalPaid);
                    break;
                case double n when (n >= 3.0 && n < 4.0):
                    Console.WriteLine("\t(L)atte: $3.00");
                    Console.WriteLine("\t(C)appuccino : $3.50");
                    DisplayPurchase(dblTotalPaid);
                    break;
                case double n when (n >= 4.00):
                    Console.WriteLine("\t(L)atte: $3.00");
                    Console.WriteLine("\t(C)appuccino : $3.50");
                    Console.WriteLine("\t(D)ecaf: $4.00");
                    DisplayPurchase(dblTotalPaid);
                    break;
                default:
                    Console.WriteLine("\tNot enough funds to purchase a coffee");
                    break;
            }
        }

        public static void DisplayPurchase(double dblTotalPaid)
        {
            bool isValid = false;
            const double dblCappuccino = 3.50;
            const double dblLatte = 3.00;
            const double dblDecaf = 4.00;

            while (!isValid)
            {
                string strResult = Console.ReadLine();
                string strChange = string.Empty;
                isValid = true;

                switch (strResult.ToLower())
                {
                    case "c":
                        strChange = CalculateChange(dblTotalPaid, dblCappuccino);
                        break;
                    case "l":
                        strChange = CalculateChange(dblTotalPaid, dblLatte);
                        break;
                    case "d":
                        strChange = CalculateChange(dblTotalPaid, dblDecaf);
                        break;
                    default:
                        isValid = false;
                        Console.WriteLine("You have entered an inivalid key selection, try again");
                        break;
                }
                if (isValid)
                {
                    if (strChange.Contains("-"))
                    {
                        Console.WriteLine("Incorrect selection");
                    }
                    else
                    {
                        GetTheCoinsFromChange(strChange).ForEach(r => Console.WriteLine("Change in coin: $" + r.ToString("0.#0")));
                        Console.Write($"Total change: ${strChange}");
                    }
                }
            }
        }

        //get coin needed for change
        //.80 - .50 = .30 - .20 = .10
        //1.35 - 1.00 = .35 - .20 = .15 - .10 = .05
        //5.55 - 2.00 = 3.55 - 2.00 = 1.55 - 1.00 = .55 - .50 = .05
        public static List<double> GetTheCoinsFromChange(string change)
        {
            double dblChange = 0;
            List<double> lstCoinChange = new List<double>();
            double.TryParse(change, out dblChange);
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


        public static string CalculateChange(double totalPaid, double coffeePrice)
        {
            return (totalPaid - coffeePrice) < 1 ? ((totalPaid - coffeePrice) * 100).ToString("0#") + " Cents" : (totalPaid - coffeePrice).ToString("0.##");
        }

        //This can be used if total amounts are enteres with 1 or 2 cents
        //private static double VerifyPaymentCoins(double amount)
        //{
        //    double newAmount = 0;
        //    var lastdigit = (amount * 100) % 10;
        //    if (lastdigit == 1 || lastdigit == 2)
        //    {
        //        double.TryParse(string.Format("{0:f1}", amount), out newAmount);
        //    }
        //    else
        //        newAmount = amount;
        //    return newAmount;
        //}
    }
}
