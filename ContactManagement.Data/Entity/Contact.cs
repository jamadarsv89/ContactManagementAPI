using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Data.Entity
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public bool IsFavourate { get; set; }

        public int StatusId { get; set; }

        public ICollection<ContactNumber> ContactNumbers { get; set; }

        public ICollection<ContactStatus> ContactStatuses { get; set; }
    }
}
