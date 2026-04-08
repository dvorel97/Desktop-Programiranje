using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Beverage:Drink
    {
        public override string Category => "Bezalkoholna pića";
        public Beverage(string name, decimal price, double quantity) : base(name, price, quantity) { }
    }
}
