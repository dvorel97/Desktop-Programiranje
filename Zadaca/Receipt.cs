using System;
using System.Collections.Generic;
using System.Text;
using Zadaca.Items;

namespace Zadaca
{
    public class Receipt
    {
        private List<IProduct> items = new();
        public decimal sum;
        
        public Receipt()
        {
            this.sum = 0;
        }

        public void AddItem(IProduct product)
        {
            items.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var item in items)
            {
                sb.AppendLine($"{item.Name} ({item.Quantity}{item.MeasuringUnit}) - {item.Price}");
            }
            return sb.ToString();
        }
         
    
    }
}
