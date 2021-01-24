using System.Collections.Generic;

namespace ContactManagement.Core
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public bool IsFavourate { get; set; }

        public ContactStatusDTO Status { get; set; }

        public ICollection<ContactNumberDTO> ContactNumbers { get; set;  }
    }
}
