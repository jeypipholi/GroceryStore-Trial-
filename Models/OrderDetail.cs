namespace GroceryStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
