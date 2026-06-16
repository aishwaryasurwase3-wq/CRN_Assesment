using CRN_Assesment.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRN_Assesment
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}