using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public static class ValidateCoin
    {
        public static bool ValidateCoinEntry(this string coin)
        {
            double validateCoin = 0;            
            return double.TryParse(coin, out validateCoin) ? (validateCoin <= 0.00 ? false : true) : false;
        }
    }
}
