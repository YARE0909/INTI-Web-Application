using Microsoft.EntityFrameworkCore;
using CreditCardPortal.Models;

namespace CreditCardPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CardApplication> CardApplications { get; set; }
    }
}
