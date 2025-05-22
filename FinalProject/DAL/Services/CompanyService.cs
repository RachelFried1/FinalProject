using DAL.Exceptions;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CompanyService
    {
        dbClass dataBase;
        public CompanyService(dbClass dataBase)
        {
            this.dataBase = dataBase;
        }
        public Company GetCompanyById(int code)
        {
            var company = dataBase.Companies.FirstOrDefault(c => c.Code == code);
            if (company == null)
                throw new CompanyNotFoundException(code);
            return company;
        }
        public void AddCompany(Company company)
        {
            if (dataBase.Companies.FirstOrDefault(c => c.Code == company.Code) != null)
                throw new CompanyAlreadyExistsException(company.Code);
            dataBase.Companies.Add(company);
            dataBase.SaveChanges();
        }
    }
}
