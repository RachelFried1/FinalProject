using AutoMapper;
using BL.Api;
using DAL;
using DAL.Exceptions;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CompanyServiceBL:ICompanyBL
    {
        private IMapper _mapper;
        IDalManager _dalManager;

        public CompanyServiceBL(IMapper mapper, IDalManager dalManager)
        {
            _dalManager = dalManager;
            _mapper = mapper;
        }
        public Company GetCompanyById(int code)
        {
            return _dalManager.CompanyManager.GetCompanyById(code);
        }
        public void AddCompany(Company company)
        {
           _dalManager.CompanyManager.AddCompany(company);
        }
    }
}
