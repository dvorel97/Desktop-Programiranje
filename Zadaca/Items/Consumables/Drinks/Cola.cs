using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Cola:Drink
    {
        public override string Category => "Bezalkoholno piće";
        public Cola() : base("Coca Cola", 2.40m, 3.33) { }
    }
}
