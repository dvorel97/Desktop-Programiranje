namespace McOrders {
  public class Order {
    public Order(int id, Food food) {
      Id = id;
      Food = food;
    }
    public int Id { get; set; }
    public Food Food { get; set; }

    public override string ToString() {
      return $"{string.Format("{0:D3}", Id)} ({Food.ToString()})";
    }
  }
}
