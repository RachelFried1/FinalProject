using AutoMapper;
using BL.Api;
using BL.Services;
using DAL;

namespace BL
{
    public class BlManager : IBlManager
    {
        public IJobBL JobBLManager { get; set; }
        public IJobSeekerBL JobSeekerBLManager { get; set; }
        public ICompanyBL CompanyBLManager { get; set; }
        public IAuth AuthManager { get; set; }

        public BlManager(IDalManager dalManager, IMapper mapper)
        {
            JobBLManager = new JobServiceBL(mapper, dalManager);
            JobSeekerBLManager = new JobSeekerServiceBL(mapper, dalManager);
            CompanyBLManager = new CompanyServiceBL(dalManager);
            AuthManager = new AuthService(mapper, dalManager);
        }
    }
}
