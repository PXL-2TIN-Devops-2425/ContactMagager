using ContactManager.AppLogic.Contracts;
using ContactManager.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactManager.Pages.Contacts
{
    public class AddContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public List<SelectListItem> CompanySelectListItems { get; set; }
        private readonly ICompanyRepository _companyRepository;
        private readonly IContactRepository _contactRepository;
        public AddContactModel(ICompanyRepository companyRepository, IContactRepository contactRepository)
        {
            Contact contact = new Contact();
            Contact = contact;
            _companyRepository = companyRepository;
            _contactRepository = contactRepository;
            CompanySelectListItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Select a company" }
            };

            // Voeg de bedrijven uit de repository toe aan de lijst
            CompanySelectListItems.AddRange(
                _companyRepository.GetAllCompanies()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
            );
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Sla de contactpersoon op
            _contactRepository.AddContact(Contact);
            //_companyRepository.AddCompany(Contact.Company);

            return RedirectToPage("/Index");
        }
    }
}