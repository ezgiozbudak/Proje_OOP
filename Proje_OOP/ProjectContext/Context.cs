using Microsoft.EntityFrameworkCore;
using Proje_OOP.Entities;

namespace Proje_OOP.ProjectContext
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database = DbNewOOPCore; integrated security = true;TrustServerCertificate=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
