using ContactUsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactUsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ContactForm> Contacts { get; set; }
    }
}
