using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.API.APIModels
{
    public class ContactAPIModel
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public bool IsFavourate { get; set; }

        public ContactStatusAPIModel Status { get; set; }

        public ICollection<ContactNumberAPIModel> ContactNumbers { get; set; }
    }
    public class ContactNumberAPIModel
    {
        public NumberTypeAPIModel Type { get; set; }

        [Required]
        [Phone]
        public string Number { get; set; }
    }
    public enum ContactStatusAPIModel
    {
        Active = 1,
        Inactive
    }

    public enum NumberTypeAPIModel
    {
        Home = 1,
        Mobile,
        Work,
        Secondary
    }
}
