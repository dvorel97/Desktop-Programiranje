using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Latte : Drink
    {
        public override string Category => "Kave";
        public Latte() : base("Latte", 1.90m, 2.8) { }
    }
}
