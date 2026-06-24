using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal abstract class Upgrades
    {
        public string Name;
        public int Cost;
        public bool Purchased;

        // Wordt door child classes ingevuld
        // Hier staat het daadwerkelijke effect van de upgrade
        public abstract void Apply(Clicker game);


        public void BuyUpgrade(Clicker game)
        {
            if (!Purchased && game.Cookies >= Cost)
            {
                game.Cookies -= Cost;

                // Pas het effect van de upgrade toe
                Apply(game);

                // Zorg ervoor dat de upgrade niet opnieuw gekocht kan worden
                Purchased = true;

                Console.WriteLine($"{Name} gekocht!");
                Console.ReadKey();
            }
            else if (!Purchased && game.Cookies < Cost)
            {
                Console.WriteLine("\nJe hebt niet genoeg geld voor deze upgrade.");
                Console.ReadKey();
            }
            else if (Purchased)
            {
                Console.WriteLine("\nJe hebt deze upgrade al gekocht.");
                Console.ReadKey();
            }
        }
    }
}