using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Data;
using CreditCardPortal.Models;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CreditCardPortal.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                Message = "Email and Password are required.";
                return Page();
            }

            // Hash the password using SHA256 (for demo purposes only)
            string hashedPassword;
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == Email);
            if (customer == null)
            {
                // Create a new user with minimal info
                customer = new Customer
                {
                    Email = Email,
                    PasswordHash = hashedPassword
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                Message = "New user created.";
            }
            else if (customer.PasswordHash != hashedPassword)
            {
                Message = "Incorrect password.";
                return Page();
            }

            // Simulate login by storing customer id (for demo only)
            HttpContext.Session.SetInt32("CustomerId", customer.Id);
            return RedirectToPage("/Index");
        }
    }
}
