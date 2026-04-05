using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Cappucino : Drink
    {
        public override string Category => "Kave";
        public Cappucino() : base("Cappucino", 1.8m, 2.5) { }
    }
}
