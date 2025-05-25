using DAL.Api;
using DAL.Models;
using DAL.Models.models;
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
        public ICompany CompanyManager { get; set; }
        
        dbClass dataBase;
        public DalManager()
        {
            dataBase = new dbClass();
            JobManager = new JobService(dataBase);
            JobSeekerManager = new JobSeekerService(dataBase);
            CompanyManager = new CompanyService(dataBase);
        }
    }
}
