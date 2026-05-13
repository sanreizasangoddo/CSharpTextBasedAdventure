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

        public void Start()
        {
            Console.WriteLine($"Cookies: {_amountCookies}");
        }

        public void Click()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    _amountCookies += 1;
                    Console.Clear();
                    Console.WriteLine($"Cookies: {_amountCookies}");
                }
            }
        }
    }
}
