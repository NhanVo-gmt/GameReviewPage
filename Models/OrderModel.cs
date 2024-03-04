namespace OrderManagementSystem.Models
{
    public class Order {
        public int OrderID { get; set; }
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