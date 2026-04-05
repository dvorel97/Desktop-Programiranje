using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Espresso : Drink
    {
        public override string Category => "Kave";
        public Espresso() : base("Espresso", 1.5m, 2) { }
    }
}
