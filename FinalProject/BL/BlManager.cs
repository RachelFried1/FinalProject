using AutoMapper;
using BL.Api;
using BL.Services;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BlManager : IBlManager
    {
        public IJobBL JobBLManager { get; set; }
        public IJobSeekerBL JobSeekerBLManager { get; set ; }      
        public ICompanyBL CompanyBLManager { get; set; }
        public IAuth AuthManager { get; set; }
        public BlManager()
        {
            IDalManager dalManager = new DalManager();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>(); 
            });
            IMapper mapper = config.CreateMapper();
            JobBLManager = new JobServiceBL(mapper, dalManager);
            JobSeekerBLManager = new JobSeekerServiceBL(mapper, dalManager);

            CompanyBLManager = new CompanyServiceBL(dalManager);
            AuthManager = new AuthService( mapper, dalManager); 

        }
    }
}
