using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Data;
using CreditCardPortal.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace CreditCardPortal.Pages.CreditCards
{
    public class SuccessModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SuccessModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AppliedCard { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
                return RedirectToPage("/Account/Login");

            var cardApplication = await _context.CardApplications.FindAsync(id);
            if (cardApplication == null || cardApplication.CustomerId != customerId)
                return RedirectToPage("/Index");

            AppliedCard = cardApplication.CardType;
            ApplicationDate = cardApplication.ApplicationDate;
            return Page();
        }
    }
}
