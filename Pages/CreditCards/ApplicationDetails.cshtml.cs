using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Models;
using CreditCardPortal.Data;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CreditCardPortal.Pages.CreditCards
{
    public class ApplicationDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ApplicationDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public CardApplication? Application { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToPage("/Account/Login");

            Application = await _context.CardApplications.FindAsync(id);

            // Check if the application belongs to the logged-in customer
            if (Application == null || Application.CustomerId != customerId)
                return RedirectToPage("/Index");

            return Page();
        }
    }
}
