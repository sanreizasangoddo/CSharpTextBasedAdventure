using CSharpTextBasedAdeventure;
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

        private List<Upgrades> _upgrades = new List<Upgrades>();

        public void PlayerInfo()
        {
            Console.WriteLine($"Cookies: {_amountCookies}");
            Console.WriteLine($"Money: ${_amountMoney}");
            Console.WriteLine("Druk op spatie voor een cookie.");
            Console.WriteLine("Typ /sell om je cookies te verkopen voor geld.");
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                PlayerInfo();

                string input = Console.ReadLine();

                if (input == "/sell")
                {
                    Sell();
                }
                else if (input == " ")
                {
                    Click();
                }
                else if (input == "/shop")
                {
                    //Shop();
                }
            }
        }

        public async Task GenerateCookies()
        {
            while (true)
            {
                int totalCps = 0;

                foreach (Upgrades upgrade in _upgrades)
                {
                    totalCps += upgrade.CookiesPerSecond;
                }

                _amountCookies += totalCps;

                Console.Clear();
                PlayerInfo();

                await Task.Delay(1000); // wacht 1 seconde
            }
        }

        public void BuyGrandma()
        {
            _upgrades.Add(new Grandma());            
        }

        private void Click()
        {
            _amountCookies += 1;
        }

        private void Sell()
        {
            _amountMoney += _amountCookies;
            _amountCookies = 0;
        }
    }
}