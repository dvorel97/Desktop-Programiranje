using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items
{
    public abstract class Consumable : IProduct
    {
        protected string name;
        protected decimal price;
        protected double quantity;
        protected string measuringUnit;

        public string Name => name;
        public decimal Price => price;
        public double Quantity => quantity;
        public string MeasuringUnit => measuringUnit;
        public abstract string Category { get; }

        protected Consumable(string name, decimal price, double quantity, string measuringUnit)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.measuringUnit = measuringUnit;
        }

    }
}
