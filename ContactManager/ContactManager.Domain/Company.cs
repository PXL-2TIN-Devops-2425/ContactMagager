using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain
{
    public class Company
    {
        [MaxLength(100)]
        public int Id { get; set; }
       
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength (100)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        [MaxLength(50)]
        public string City { get; set; }

        public List<Contact> Contacts { get; set; }

        public Company()
        {
            Contacts = new List<Contact>();
            Name = string.Empty;
            Address=string.Empty;
            Zip = string.Empty;
            City = string.Empty;
        }
    }
}
