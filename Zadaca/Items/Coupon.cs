using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca.Items
{
    public class Coupon : IProduct
    {
        public string name;
        public decimal price;
        public double quantity;
        public string measuringUnit;

        public string Name => name;
        public decimal Price => price;
        public double Quantity => quantity;
        public string MeasuringUnit => measuringUnit;
        public string Category => "Kuponi";

        public Coupon(decimal price, double quantity, string measuringUnit="€")
        {
            this.name = "Kupon";
            this.price = price;
            this.quantity = quantity;
            this.measuringUnit = measuringUnit;
        }
        public override string ToString()
        {
            return $"{this.name} ({this.quantity}{this.measuringUnit}) - {this.price}€";
        }

    }
}
