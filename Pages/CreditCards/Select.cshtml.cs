using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Data;
using CreditCardPortal.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace CreditCardPortal.Pages.CreditCards
{
    public class SelectModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SelectModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string SelectedCard { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(SelectedCard))
            {
                ModelState.AddModelError(string.Empty, "Please select a card type.");
                return Page();
            }

            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToPage("/Account/Login");

            // Create a new card application record.
            var cardApplication = new CardApplication
            {
                CustomerId = customerId.Value,
                CardType = SelectedCard,
                ApplicationDate = DateTime.UtcNow
            };

            _context.CardApplications.Add(cardApplication);
            await _context.SaveChangesAsync();

            return RedirectToPage("/CreditCards/Success", new { id = cardApplication.Id });
        }
    }
}
