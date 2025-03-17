using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Models;
using CreditCardPortal.Data;
using CreditCardPortal.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CreditCardPortal.Pages.Account
{
    public class KycModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public KycModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KycViewModel Kyc { get; set; } = new KycViewModel();

        public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToPage("/Account/Login");

            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                // Prefill the KYC view model with existing data from the customer record
                Kyc.FullName = customer.FullName ?? string.Empty;
                Kyc.Address = customer.Address ?? string.Empty;
                Kyc.PhoneNumber = customer.PhoneNumber ?? string.Empty;
                Kyc.EmploymentStatus = customer.EmploymentStatus ?? string.Empty;
                Kyc.MaritalStatus = customer.MaritalStatus ?? string.Empty;
                if (customer.DateOfBirth.HasValue)
                {
                    Kyc.DateOfBirth = customer.DateOfBirth.Value;
                }
                Kyc.Gender = customer.Gender ?? string.Empty;
                Kyc.Nationality = customer.Nationality ?? string.Empty;
                Kyc.AnnualIncome = customer.AnnualIncome.HasValue ? customer.AnnualIncome.Value : 0;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToPage("/Account/Login");

            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
                return RedirectToPage("/Account/Login");

            // Update the customer's record with the KYC details.
            customer.FullName = Kyc.FullName;
            customer.Address = Kyc.Address;
            customer.PhoneNumber = Kyc.PhoneNumber;
            customer.EmploymentStatus = Kyc.EmploymentStatus;
            customer.MaritalStatus = Kyc.MaritalStatus;
            customer.DateOfBirth = Kyc.DateOfBirth;
            customer.Gender = Kyc.Gender;
            customer.Nationality = Kyc.Nationality;
            customer.AnnualIncome = Kyc.AnnualIncome;

            await _context.SaveChangesAsync();

            // Redirect to card selection page after KYC is complete.
            return RedirectToPage("/CreditCards/Select");
        }
    }
}
