using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Fanta : Drink
    {
        public override string Category => "Bezalkoholno piće";
        public Fanta() : base("Fanta", 2.0m, 3) { }
    }
}
