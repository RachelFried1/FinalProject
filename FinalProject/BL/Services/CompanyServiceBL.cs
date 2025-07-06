using AutoMapper;
using BL.Api;
using BL.Models;
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
        IDalManager _dalManager;

        public CompanyServiceBL( IDalManager dalManager)
        {
            _dalManager = dalManager;
        }
        public Company GetCompanyById(int code)
        {
            return _dalManager.CompanyManager.GetCompanyById(code);
        }
        
    }
}
