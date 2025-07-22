using DAL.Api;
using DAL.Exceptions;
using DAL.Models.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CompanyService : ICompany
    {
        dbClass dataBase;
        public CompanyService(dbClass dataBase)
        {
            this.dataBase = dataBase;
        }
        public Company GetCompanyById(int code)
        {
            return dataBase.Companies
                .Include(c => c.UserPassword)
                .FirstOrDefault(c => c.Code == code);
        }
        public Company GetCompanyByEmail(string email)
        {
            var company = dataBase.Companies
                .Include(c => c.UserPassword)
                .FirstOrDefault(c => c.Email == email);
            if (company == null)
                throw new CompanyNotFoundException(email);
            return company;
        }
        public void AddCompany(Company company)
        {
            if (dataBase.Companies.Any(c => c.Code == company.Code))
                throw new CompanyAlreadyExistsException(company.Code);
            if (dataBase.Companies.Any(c => c.Email == company.Email))
                throw new CompanyAlreadyExistsException(company.Email);
        
                    dataBase.Companies.Add(company);
            dataBase.SaveChanges();
        }
    }
}