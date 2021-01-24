using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManagement.Data.Entity
{
    public class ContactNumberType
    {
        [Key]
        public int Id { get; set; }

        public string NumberType { get; set; }

        [ForeignKey("ContactNumberId")]
        public ContactNumber ContactNumber { get; set; }

        public int ContactNumberId { get; set; }
    }
}
