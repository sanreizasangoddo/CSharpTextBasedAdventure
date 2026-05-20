using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class Clicker
    {
        private int _amountCookies;
        private int _amountMoney;

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Cookies: {_amountCookies}");
                Console.WriteLine($"Money: ${_amountMoney}");
                Console.WriteLine("Druk op spatie voor een cookie of s om ze te verkopen.");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
                    Sell();
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    Click();
                }
            }
        }

        public void Click()
        {
            _amountCookies += 1;
        }

        public void Sell()
        {
            _amountMoney += _amountCookies;
            _amountCookies = 0;
        }
    }
}