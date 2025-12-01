namespace OrderManagementApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }   // ← REQUIRED

        public decimal TotalAmount { get; set; } // ← REQUIRED

        public string UserName { get; set; } = string.Empty;
    }
}
