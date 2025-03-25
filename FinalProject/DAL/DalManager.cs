using DAL.Api;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalManager : IDalManager
    {
        public IJob JobManager { get; set; }
        public IJobSeeker JobSeekerManager { get ; set ; }
        public IJobOffers JobOffersManager { get; set; }
        public DalManager()
        {
            JobManager = new JobService();
            JobSeekerManager = new JobSeekerService();  
            JobOffersManager = new JobOffersService();
        }
    }
}
