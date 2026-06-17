using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdeventure
{
    internal abstract class Upgrades
    {
        public string Name;
        public int Cost;
        public bool Purchased;

        public abstract void Apply(Clicker game);
    }
}
