using ContactManager.AppLogic.Contracts;
using ContactManager.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactManager.Pages.Companies
{
    public class AddCompanyModel : PageModel
    {
        [BindProperty]
        public Company Company { get; set; }
        public ICompanyRepository _companyRepository;

        public AddCompanyModel(ICompanyRepository companyRepository)
        {
            Company company = new Company();
            Company = company;
            _companyRepository = companyRepository;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ModelState.IsValid)
            {
                _companyRepository.AddCompany(Company);
                return RedirectToPage("/Index");
            }
            return Page();

        }
    }

}
