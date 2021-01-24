using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManagement.Data.Entity
{
    public class ContactNumber
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public ICollection<ContactNumberType> ContactNumberTypes { get; set; }

        public int NumberType { get; set; }

        public string Number { get; set; }

        [ForeignKey("ContactId")] 
        public Contact contact { get; set; }
    }
}
