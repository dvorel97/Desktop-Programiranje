using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables
{
    public abstract class Dessert : Consumable
    {
        public override string Category => "Deserti";

        protected Dessert(string name, decimal price) : base(name, price, 1, "kom")
        {
        }
    }
}

