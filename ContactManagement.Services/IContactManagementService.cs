using ContactManagement.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagement.Services
{
    public interface IContactManagementService
    {
        Task<ICollection<ContactDTO>> GetAllContacts();

        Task CreateContact(ContactDTO contact);

        Task<ContactDTO> GetContact(int id);

        Task DeleteContact(int id);

        Task UpdateContact(ContactDTO contact);
    }
}
