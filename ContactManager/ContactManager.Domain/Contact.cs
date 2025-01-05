using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain
{
    public class Contact
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public Contact()
        {
            Name=string.Empty;
            FirstName=string.Empty;
            Email=string.Empty;
            Phone = string.Empty;
        }
    }
}