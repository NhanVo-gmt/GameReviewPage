namespace OrderManagementSystem.Models
{
    public enum OrderStatus {
        Pending,
        Processing,
        Shipped,
        Deliverd,
    }

    public class Order {
        public int OrderID { get; set; }
        public OrderStatus OrderStatus {get; set;}
        public DateTime Date { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set;}
    }

    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}