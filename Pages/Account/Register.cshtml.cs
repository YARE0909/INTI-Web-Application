using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Models;
using CreditCardPortal.Data;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace CreditCardPortal.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = new Customer();

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Hash the password using SHA256 (for demo purposes only)
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                Customer.PasswordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            // In a complete system, you would log the user in and redirect appropriately.
            return RedirectToPage("/CreditCards/Select");
        }
    }
}
