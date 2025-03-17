using System;

namespace CreditCardPortal.Models
{
    public class CardApplication
    {
        public int Id { get; set; }

        // Foreign key to the customer
        public int CustomerId { get; set; }

        // The type of card applied for (e.g. Standard, Gold, Platinum)
        public string CardType { get; set; } = string.Empty;

        // When the application was made
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;

        // New fields for additional details
        public string Status { get; set; } = "Pending";  // e.g., Pending, Approved, Rejected
        public string? Remarks { get; set; }              // Optional remarks

        // Navigation property
        public Customer? Customer { get; set; }
    }
}
