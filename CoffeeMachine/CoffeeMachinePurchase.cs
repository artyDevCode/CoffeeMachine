using System;
using System.Collections.Generic;

namespace CoffeeMachine
{

    public class CoffeeMachinePurchase
    {
        static void Main()
        {

            //display coffee available and price of each coffee
            Console.WriteLine("Coffee types available");
            Console.WriteLine("\t(C)appuccino : $3.50");
            Console.WriteLine("\t(L)atte: $3.00");
            Console.WriteLine("\t(D)ecaf: $4.00");

            Console.WriteLine("Enter your payment amount (in coins only): ie 20 Cents = .20, $2 coin = 2");
            CoffeeMachine1 _cm = new CoffeeMachine1();
            double dblTotalPaid = 0.00; //sum coin value 
            string strEntry = string.Empty;
            List<KeyValuePair<string, string>> coffeeAvailable = new List<KeyValuePair<string, string>>();
            while (dblTotalPaid < 4)
            {
                //check is its a valid numeric entry
                strEntry = Console.ReadLine();
                if (strEntry.ValidateCoinEntry())
                {
                    double coinEntered = _cm.GetCoinEntries(Convert.ToDouble(strEntry));
                    dblTotalPaid += coinEntered;
                    if (coinEntered == 0.00) Console.WriteLine("Invalid coin");

                    coffeeAvailable = _cm.GetAvailableCoffee(dblTotalPaid);
                    foreach (var item in coffeeAvailable)
                    {
                        Console.WriteLine($"\t{item.Value}");

                    }
                }
                else
                {
                    if (!_cm.ValidateCoffeeInitial(strEntry)) Console.WriteLine("Invalid entry"); else break;
                }
            };

            //Prompt if the coins entered are greater or equal to $4
            while (true)
            {
                if (dblTotalPaid >= 4) strEntry = Console.ReadLine();

                if (_cm.ValidateCoffeeInitial(strEntry))
                {
                    //check against the coffee available
                    if (coffeeAvailable.Exists(r => r.Key == strEntry))
                    {

                        double strChange = 0;
                        strChange = _cm.SelectCoffeeToPurchase(dblTotalPaid, strEntry);

                        _cm.GetTheCoinsFromChange(Math.Round((Double)strChange, 2)).ForEach(r => Console.WriteLine("Change in coin: $" + r.ToString("0.#0")));
                        Console.Write($"Total change: ${strChange.ToString("0.#0")}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry");
                        strEntry = Console.ReadLine();
                    }
                }
                else Console.WriteLine("Invalid entry. Must be 'l', 'c' or 'd'");
            }
        }
    }
}
