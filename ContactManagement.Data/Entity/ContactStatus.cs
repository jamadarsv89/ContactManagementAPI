using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Data.Entity
{
    public class ContactStatus
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }

        public ICollection<Contact> Contacts {get; set;}
    }
}
