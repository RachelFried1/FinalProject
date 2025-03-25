using DAL.Api;
using DAL.Models;
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
        public IJobSeeker JobSeekerManager { get; set; }
        public IJobOffers JobOffersManager { get; set; }
        dbClass dataBase;
        public DalManager()
        {
            dataBase = new dbClass();
            JobOffersManager = new JobOffersService(dataBase);
            JobManager = new JobService(JobOffersManager, dataBase);
            JobSeekerManager = new JobSeekerService(JobOffersManager, dataBase);
        }
    }
}
