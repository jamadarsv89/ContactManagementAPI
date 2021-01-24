using ContactManagement.Data.Entity;

namespace ContactManagement.Data
{
    public class ContactRepository: GenericRepository<Contact>
    {
        public ContactRepository(ContactDbContext dbContext): base(dbContext)
        {

        }
    }
}
