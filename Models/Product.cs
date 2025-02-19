namespace GroceryStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
