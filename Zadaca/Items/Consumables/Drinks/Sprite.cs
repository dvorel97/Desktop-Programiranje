using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Sprite : Drink
    {
        public override string Category => "Bezalkoholno piće";
        public Sprite() : base("Sprite", 2.20m, 3) { }
    }
}
