namespace GroceryStore.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
