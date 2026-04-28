using System.ComponentModel.Design;

namespace McOrders {
  public class Ordering {
    public Ordering() {
        nextOrderId = 1;
        CompletedOrders = new List<Order>();
        ActiveOrders = new List<Order>();
    }

    public void AddOrder(Food food) {
      var order = new Order(nextOrderId++, food);
      Task task = Task.Run(() => {
        StartOrder(order);
        Thread.Sleep(order.Food.PreparingTime * 1000);
        CompleteOrder(order);
      });
    }

    public void StartOrder(Order order) {
      ActiveOrders.Add(order);
      OrderStarted?.Invoke(this, new OrderArgs(order));
    }

    // TODO: Metoda koja prebacuje narudžbu iz aktivnih u završene
    // TODO: Mora pokrenuti događaj koji signalizira završetak
    // narudžbe
    public void CompleteOrder(Order order) {
        if (ActiveOrders.Contains(order))
        {
            ActiveOrders.Remove(order);
        }
        CompletedOrders.Add(order);
        OrderCompleted?.Invoke(this, new OrderArgs(order));
        }

    public delegate void OrderingDelegate(object sender, OrderArgs e);
    public event OrderingDelegate OrderStarted;
    public event OrderingDelegate OrderCompleted;
    // TODO: Događaj za završene narudžbe

    public List<Order> ActiveOrders { get; }
    public List<Order> CompletedOrders { get; }
        // TODO: List završenih narudžbi

        private int nextOrderId;
  }
}
