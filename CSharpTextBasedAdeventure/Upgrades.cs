using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class Upgrades
    {
        public string Name;
        public int Cost;
        public int CookiesPerSecond;
        public int AmountOwned;

        public Upgrades(string name, int cost, int cps)
        {
            Name = name;
            Cost = cost;
            CookiesPerSecond = cps;
            AmountOwned = 0;
        }

        public virtual void Info()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Buy: {Cost}");
            Console.WriteLine($"CPS: {CookiesPerSecond}");
        }
    }
}
