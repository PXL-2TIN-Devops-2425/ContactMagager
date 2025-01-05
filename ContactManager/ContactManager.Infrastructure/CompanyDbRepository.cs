using ContactManager.AppLogic.Contracts;
using ContactManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure
{
    internal class CompanyDbRepository : ICompanyRepository
    {
        
        private readonly ContactManagerDbContext dbContext;

        public CompanyDbRepository(ContactManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddCompany(Company company)
        {
            dbContext.Companys.Add(company);   
            dbContext.SaveChanges();
        }

        public IList<Company> GetAllCompanies()
        {
            return dbContext.Companys.ToList();
        }
    }
}
