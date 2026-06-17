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

        public virtual void Info()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"CPS: {CookiesPerSecond}");
        }
    }
}