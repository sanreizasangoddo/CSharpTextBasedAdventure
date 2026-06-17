using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class BetterClicks : Upgrades
    {
        public BetterClicks()
        {
            Name = "Better Clicks";
            Cost = 1000;
        }

        public override void Apply(Clicker game)
        {
            game.ClickMultiplier *= 2f;
        }
    }
}