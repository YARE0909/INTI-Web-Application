using System;
using System.Collections.Generic;

namespace CreditCardPortal.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // KYC fields
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmploymentStatus { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public decimal? AnnualIncome { get; set; }

        // Navigation property: one customer can have many card applications.
        public List<CardApplication> CardApplications { get; set; } = new List<CardApplication>();
    }
}
