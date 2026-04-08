using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Beverage:Drink
    {
        public override string Category => "Bezalkoholno piće";
        public Beverage(string name, decimal price, double quantity) : base(name, price, quantity) { }
    }
}
