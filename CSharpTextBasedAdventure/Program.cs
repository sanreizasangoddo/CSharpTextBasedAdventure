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
            Clicker game = new Clicker();

            _ = game.GenerateCookies();

            game.Start();
        }
    }
}