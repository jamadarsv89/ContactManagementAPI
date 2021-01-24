using ContactManagement.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data
{
    public class ContactDbContext: DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options): base(options)
        {
            
        }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<ContactNumber> ContactNumbers { get; set; }

        public DbSet<ContactNumberType> ContactNumberType { get; set; }

        public DbSet<ContactStatus> ContactStatus { get; set; }
    }
}
