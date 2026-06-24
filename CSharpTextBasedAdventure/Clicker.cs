using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        // Laat upgrades direct het aantal cookies aanpassen
        public float Cookies
        {
            get => _amountCookies;
            set => _amountCookies = value;
        }

        private string _lastEventMessage;

        private List<Buildings> _buildings = new List<Buildings>()
        {
            new Grandma(),
            new Factory()
        };

        private List<Upgrades> _upgrades = new List<Upgrades>()
        {
            new BetterClicks(),
            new BetterGrandmas()
        };

        Grandma grandma = new Grandma();
        Factory factory = new Factory();

        private Random _random = new Random();

        public void Start()
        {
            while (true)
            {
                PlayerInfo();

                if (CheckWin())
                {
                    break;
                }

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
                    int maxChoice = _buildings.Count + _upgrades.Count;

                    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > maxChoice)
                    {
                        Shop();
                        Console.WriteLine("\nOngeldig keuze. Typ opnieuw in.");
                    }

                    if (choice == 0)
                    {
                        Console.Clear();
                        continue;
                    }

                    if (choice <= _buildings.Count)
                    {
                        BuyBuilding(choice);
                    }
                    else
                    {
                        int upgradeIndex = choice - _buildings.Count - 1;

                        _upgrades[upgradeIndex].BuyUpgrade(this);
                    }
                }

                Console.Clear();
            }
        }

        public async Task GenerateCookies()
        {
            while (true)
            {
                int totalCps = 0;

                // Bereken de totale cookies per seconde van alle gebouwen
                foreach (Buildings building in _buildings)
                {
                    totalCps += building.GetCps();
                }

                _amountCookies += totalCps;

                // 5% kans per seconde op een random event
                if (_random.Next(100) < 5)
                {
                    TriggerRandomEvent();
                }

                // Wacht 1 seconde voordat de volgende productie plaatsvindt
                await Task.Delay(1000);
            }
        }

        private void Shop()
        {
            Console.Clear();
            Console.WriteLine($"Cookies: {_amountCookies}");
            Console.WriteLine($"Money: $ {_amountMoney}");
            Console.WriteLine("\n=== SHOP ===");
            Console.WriteLine("\nBuildings:");

            int number = 1;

            foreach (Buildings building in _buildings)
            {
                Console.WriteLine($"{number}. {building.Name} - $ {building.Cost}");
                number++;
            }
            
            grandma.Info();
            factory.Info();

            Console.WriteLine("\nUpgrades:");

            foreach (Upgrades upgrade in _upgrades)
            {
                string status = upgrade.Purchased ? "(GEKOCHT)" : "";

                Console.WriteLine($"{number}. {upgrade.Name} - {upgrade.Cost} cookies {status}");
                number++;
            }

            Console.WriteLine("\n0. Terug");
        }

        private void TriggerRandomEvent()
        {
            // Kies een willekeurig event tussen 0 en 4
            int eventID = _random.Next(5);
           
            switch (eventID)
            {
                case 0:
                    _lastEventMessage = "\nGolden Cookie! +100 cookies\n";
                    _amountCookies += 100;
                    break;

                case 1:
                    _lastEventMessage = "\nGrandma Party! CPS verdubbeld voor deze seconde.\n";
                    int totalCps = 0;

                    foreach (Buildings building in _buildings)
                    {
                        totalCps += building.GetCps();
                    }

                    _amountCookies += totalCps;
                    break;

                case 2:
                    _lastEventMessage = "\nMuis heeft koekjes gestolen... -50 cookies\n";
                    _amountCookies = Math.Max(0, _amountCookies - 50);
                    break;

                case 3:
                    _lastEventMessage = "\nIemand heeft wat geld in je cookies geïnvesteerd! + $ 250\n";
                    _amountMoney += 250;
                    break;

                case 4:
                    _lastEventMessage = "\nJe moet belasting betalen... - $ 100\n";
                    _amountMoney = Math.Max(0, _amountMoney - 100);
                    break;
            }
        }

        // Tekent het hoofdscherm van de speler
        // Wordt telkens opnieuw weergegeven
        public void PlayerInfo()
        {
            Console.WriteLine($"Cookies: {_amountCookies}");
            Console.WriteLine($"Money: $ {_amountMoney}");

            if (!string.IsNullOrEmpty(_lastEventMessage))
            {
                Console.WriteLine($"\nEVENT: {_lastEventMessage}");
            }

            Console.WriteLine("Druk op spatie en dan op enter voor een cookie.");
            Console.WriteLine("Typ /sell om je cookies te verkopen voor geld.");
            Console.WriteLine("Typ /shop om naar de shop te gaan.");
        }

        public void BuyBuilding(int index)
        {
            // Zet de gekozen shop-optie om naar het juiste gebouw
            Buildings choice = _buildings[index - 1];

            if (_amountMoney >= choice.Cost)
            {
                _amountMoney -= choice.Cost;
                choice.AmountOwned++;

                // Verhoog de prijs voor de volgende aankoop
                choice.Cost = (int)(choice.Cost * 1.2);

                Console.WriteLine($"\nJe hebt een {choice.Name} gekocht!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nJe hebt niet genoeg geld.");
                Console.ReadKey();
            }
        }

        private void Click()
        {
            _amountCookies += 1 * ClickMultiplier;

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

        private bool CheckWin()
        {
            if (_amountCookies >= 100000)
            {
                Console.Clear();
                Console.WriteLine("EINDE: Master Baker");
                Console.WriteLine("Je hebt 100.000 cookies verzameld!");
                return true;
            }

            if (_amountMoney >= 1000000)
            {
                Console.Clear();
                Console.WriteLine("EINDE: Cookie Miljonair");
                Console.WriteLine("Je hebt $ 1.000.000 verdient!");
                return true;
            }

            return false;
        }
    }
}