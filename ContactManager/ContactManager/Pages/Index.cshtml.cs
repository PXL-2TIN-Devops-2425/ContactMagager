using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Domain;
using Microsoft.AspNetCore.Mvc;
using ContactManager.AppLogic.Contracts;


namespace ContactManager.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Contact> Contacts { get; set; }
        public IContactRepository ContactRepository { get; set; }

        public IndexModel(IContactRepository contactRepository)
        {
            ContactRepository = contactRepository;
        }

        public void OnGet()
        {
            Contacts = ContactRepository.GetAllContacts();
        }
    }
}