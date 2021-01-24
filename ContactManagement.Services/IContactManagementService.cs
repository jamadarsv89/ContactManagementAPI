using ContactManagement.Core;
using System.Collections.Generic;

namespace ContactManagement.Services
{
    public interface IContactManagementService
    {
        ICollection<ContactDTO> GetAllContacts();

        void CreateContact(ContactDTO contact);

        ContactDTO GetContact(int id);

        void DeleteContact(int id);

        void UpdateContact(ContactDTO contact);
    }
}
