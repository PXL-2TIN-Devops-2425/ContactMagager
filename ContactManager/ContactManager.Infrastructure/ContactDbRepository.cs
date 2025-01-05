using ContactManager.AppLogic.Contracts;
using ContactManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure
{
    internal class ContactDbRepository:IContactRepository
    {
        private readonly ContactManagerDbContext contactManagerDbContext;

        public ContactDbRepository(ContactManagerDbContext contactManagerDbContext)
        {
            this.contactManagerDbContext = contactManagerDbContext;
        }

        public IList<Contact> GetAllContacts()
        {

            return contactManagerDbContext.Contacts.Include(c => c.Company).ToList();
            
        }
        public void AddContact(Contact contact)
        {
            contactManagerDbContext.Contacts.Add(contact);
            contactManagerDbContext.SaveChanges();
        }
    }
}
