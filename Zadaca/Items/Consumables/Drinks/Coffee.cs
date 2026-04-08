using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace Zadaca.Items.Consumables.Drinks
{
    internal class Coffee : Drink
    {
        public override string Category => "Kave";
        public Coffee(string name, decimal price, double quantity) : base(name, price, quantity) { }
    }
}
