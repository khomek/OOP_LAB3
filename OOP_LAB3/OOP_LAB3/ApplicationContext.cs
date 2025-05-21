using Microsoft.EntityFrameworkCore;
using OOP_LAB3.Models;

namespace OOP_LAB3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Writer> Writers => Set<Writer>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<BookCustomer> BookCustomers => Set<BookCustomer>();
        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
    

    
}
