using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditCardPortal.Data;
using CreditCardPortal.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardPortal.Pages.CreditCards
{
    public class ApplicationsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ApplicationsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CardApplication> CardApplications { get; set; } = new List<CardApplication>();

        public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToPage("/Account/Login");
            }
            CardApplications = _context.CardApplications
                .Where(ca => ca.CustomerId == customerId)
                .OrderByDescending(ca => ca.ApplicationDate)
                .ToList();

            return Page();
        }
    }
}
