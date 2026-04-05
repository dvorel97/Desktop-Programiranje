using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Zadaca.Items.Consumables
{
    public abstract class Drink : Consumable
    {
        protected Drink(string name, decimal price, double quantity) : base(name, price, quantity, "dcl")
        {
        }
    }
}
