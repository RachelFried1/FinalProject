using BL.Models;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface ICompanyBL
    {
        Company GetCompanyById(int code);
        
    }
}
