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

        public JobService( IJobOffers jobOffersService, dbClass dataBase)
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

        public List<JobSeeker> FindMatchingCandidates(int code)
        {
            List<JobSeeker> candidates = new List<JobSeeker>();
            candidates = jobOffersService.FindCandidatesByJobCode(code);
            return candidates;
        }

        public bool NotSeekingWorkers(int code)
        {
            foreach (JobOffer offer in dataBase.JobOffers)
            {
                if (offer.JobCode == code)
                {
                    dataBase.JobOffers.Remove(offer);
                    dataBase.SaveChanges();
                }
            }
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == code) != null)
            {
                dataBase.Jobs.Remove(dataBase.Jobs.FirstOrDefault(j => j.Code == code));
                dataBase.SaveChanges();
                return true;
            }
            return false;          
        }
    }
}
