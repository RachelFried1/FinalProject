using BL.Api;
using BL.Services;
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
        public IJobOffersBL JobOffersBLManager { get ; set; }

        public BlManager()
        {
            JobBLManager = new JobServiceBL();
            JobSeekerBLManager = new JobSeekerServiceBL();
            JobOffersBLManager = new JobOffersServiceBL();
        }
    }
}
