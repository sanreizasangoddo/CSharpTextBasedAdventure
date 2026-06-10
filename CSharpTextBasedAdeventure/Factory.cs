using CSharpTextBasedAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextBasedAdventure
{
    internal class Factory : Upgrades
    {
        public Factory() : base("Factory", 500, 5)
        {

        }

        public override void Info()
        {
            base.Info();
        }
    }
}
