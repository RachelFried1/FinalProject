using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobService : IJob
    {
        IJobOffers jobOffersService;
        dbClass dataBase;

        public JobService(IJobOffers jobOffersService, dbClass dataBase)
        {
            this.jobOffersService = jobOffersService;
            this.dataBase = dataBase;
        }
        public bool AddJob(Job job)
        {
            dataBase.Jobs.Add(job);
            dataBase.SaveChanges();

            jobOffersService.AddCandidates(job);
            return true;
        }

        public ICollection<JobOffer> FindMatchingCandidates(int code)
        {
            return jobOffersService.FindCandidatesByJobCode(code);
        }

        public bool NotSeekingWorkers(int code)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == code) == null)
                return false;
            dataBase.Jobs.FirstOrDefault(j=>j.Code == code).JobOffers.Clear();
            dataBase.Jobs.Remove(dataBase.Jobs.FirstOrDefault(j => j.Code == code));
            dataBase.SaveChanges();
            return true;
        }
    }
}
