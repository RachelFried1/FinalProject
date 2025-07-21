using BL.Models;
using DAL.Exceptions;
using DAL.Models.models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IAuth
    {
        void SignUpJobSeeker(JobSeekerBL seeker, string password);

        void SignUpCompany(CompanyBL company, string password);

        string SignInJobSeeker(string email, string password);

        string SignInCompany(string email, string password); 
    }
}
