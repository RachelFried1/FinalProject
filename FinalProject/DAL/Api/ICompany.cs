using DAL.Exceptions;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface ICompany
    {
        Company GetCompanyById(int code);
        Company GetCompanyByEmail(string email);
        void AddCompany(Company company);
    }
}
