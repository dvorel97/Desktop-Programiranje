using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca
{
    public abstract class Consumable : IProduct
    {
        protected string name;
        protected decimal price;
        protected int quantity;
        protected string measuringUnit;
        protected int calories;

        public string Name => name;
        public decimal Price => price;
        public int Calories => calories;
        public int Quantity => quantity;
        public string MeasuringUnit => measuringUnit;
        public abstract string Category { get; }

        protected Consumable(string name, decimal price, int calories, int quantity, string measurinUnit)
        {
            this.name = name;
            this.price = price;
            this.calories = calories;
            this.quantity = quantity;
            this.measuringUnit = measurinUnit;
        }

    }
}
