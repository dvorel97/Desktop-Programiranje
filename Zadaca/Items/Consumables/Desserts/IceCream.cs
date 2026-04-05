using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items.Consumables.Desserts
{
    internal class IceCream : Dessert
    {
        public IceCream() : base("Sladoled", 1m) 
        {
            this.measuringUnit = "kuglica";
        }
    }
}
