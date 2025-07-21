using BL.Models;

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