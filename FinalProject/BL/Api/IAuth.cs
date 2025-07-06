using BL.Models;
using DAL.Exceptions;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IAuth
    {
        
        void SignUpJobSeeker(JobSeekerBL seeker, string password);

        void SignUpCompany(CompanyBL company, string password);

        public string SignIn(string email, string password);

    }
}
