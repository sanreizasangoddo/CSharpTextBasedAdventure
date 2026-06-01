using CSharpTextBasedAdeventure;
using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Upgrades> upgrades = new List<Upgrades>();
            upgrades.Add(new Grandma());
            upgrades.Add(new Factory());

            foreach (Upgrades u in upgrades)
            {
                u.Info();
            }

            Clicker game = new Clicker();

            _ = game.GenerateCookies();

            game.Start();
        }
    }
}
