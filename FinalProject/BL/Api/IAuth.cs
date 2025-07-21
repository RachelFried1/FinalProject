using BL.Models;

namespace BL.Api
{
    public interface IAuth
    {
        string SignUpJobSeeker(JobSeekerBL seeker, string password);
        string SignUpCompany(CompanyBL company, string password);
        string SignInJobSeeker(string email, string password);
        string SignInCompany(string email, string password);
    }
}