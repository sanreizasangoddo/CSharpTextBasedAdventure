using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class BetterGrandmas : Upgrades
    {
        public BetterGrandmas()
        {
            Name = "Better Grandmas";
            Cost = 5000;
        }

        public override void Apply(Clicker game)
        {
            game.ClickMultiplier *= 4f;
        }
    }
}
