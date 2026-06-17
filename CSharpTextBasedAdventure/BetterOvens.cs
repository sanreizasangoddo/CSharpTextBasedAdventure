using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdeventure
{
    internal class BetterOvens : Upgrades
    {
        public BetterOvens()
        {
            Name = "Better Ovens";
            Cost = 1000;
        }

        public override void Apply(Clicker game)
        {
            game.ClickMultiplier *= 2f;
        }
    }
}
