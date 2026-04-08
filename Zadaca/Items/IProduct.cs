
using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        double Quantity { get; }
        string MeasuringUnit { get; }
        string Category { get; }
    }
}
