namespace GroceryStore.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public int LoyaltyPoints { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
