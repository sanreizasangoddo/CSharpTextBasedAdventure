using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class Buildings
    {
        public string Name;
        public int Cost;
        public int CookiesPerSecond;
        public int AmountOwned;

        public Buildings(string name, int cost, int cps)
        {
            Name = name;
            Cost = cost;
            CookiesPerSecond = cps;
            AmountOwned = 0;
        }

        // Kan door child classes worden overschreven om extra informatie te tonen
        public virtual void Info()
        {
            Console.WriteLine($"\n{Name}:");
        }

        // Berekent de totale CPS van dit gebouw
        // Child classes kunnen dit overschrijven voor speciale effecten
        public virtual int GetCps()
        {
            return CookiesPerSecond * AmountOwned;
        }
    }
}