using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCardPortal.ViewModels
{
    public class KycViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Employment Status is required.")]
        public string EmploymentStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "Marital Status is required.")]
        public string MaritalStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; } = string.Empty;

        [Required(ErrorMessage = "Annual Income is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Annual Income must be a positive number.")]
        public decimal AnnualIncome { get; set; }
    }
}
