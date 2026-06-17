using CSharpTextBasedAdeventure;
using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpTextBasedAdventure
{
    internal class Clicker
    {
        private float _amountCookies;
        private float _amountMoney;
        public float ClickMultiplier { get; set; } = 1f;

        private List<Buildings> _buildings = new List<Buildings>()
        {
            new Grandma(),
            new Factory()
        };

        private List<Upgrades> _upgrades = new List<Upgrades>()
        {
            new BetterOvens()
        };

        Grandma grandma = new Grandma();
        Factory factory = new Factory();

        public void Start()
        {
            while (true)
            {
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
                    Shop();

                    int choice;

                    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > _buildings.Count)
                    {
                        Shop();
                        Console.WriteLine("\nOngeldig keuze. Typ opnieuw in.");
                    }

                    if (choice == 0)
                    {
                        Console.Clear();
                        continue;
                    }

                    BuyBuilding(choice);
                }

                Console.Clear();
            }
        }

        public async Task GenerateCookies()
        {
            while (true)
            {
                int totalCps = 0;

                foreach (Buildings upgrade in _buildings)
                {
                    totalCps += upgrade.CookiesPerSecond * upgrade.AmountOwned;
                }

                _amountCookies += totalCps;

                await Task.Delay(1000); // wacht 1 seconde
            }
        }

        public void Shop()
        {
            Console.Clear();
            Console.WriteLine($"Money: $ {_amountMoney}");
            Console.WriteLine("\n=== SHOP ===");

            for (int i = 0; i < _buildings.Count; i++)
            {
                Buildings b = _buildings[i];
                Console.WriteLine($"{i + 1}. {b.Name} - $ {b.Cost}");
            }

            Console.WriteLine("\n0. Terug");
        }

        public void PlayerInfo()
        {
            Console.WriteLine($"Cookies: {_amountCookies}");
            Console.WriteLine($"Money: ${_amountMoney}");
            Console.WriteLine("Druk op spatie en dan op enter voor een cookie.");
            Console.WriteLine("Typ /sell om je cookies te verkopen voor geld.");
            Console.WriteLine("Typ /shop om naar de shop te gaan.\n");
        }

        public void BuyBuilding(int index)
        {
            Buildings choice = _buildings[index - 1];

            if (_amountMoney >= choice.Cost)
            {
                _amountMoney -= choice.Cost;
                choice.AmountOwned++;

                choice.Cost = (int)(choice.Cost * 1.2);
                
                Console.WriteLine($"\nJe hebt een {choice.Name} gekocht!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nJe hebt niet genoeg cookies.");
                Console.ReadKey();
            }
        }

        private void Click()
        {
            _amountCookies += 1;

            Console.Clear();
            PlayerInfo();
        }

        private void Sell()
        {
            _amountMoney += _amountCookies * 1.75f;
            _amountCookies = 0;

            Console.Clear();
            PlayerInfo();
        }
    }
}