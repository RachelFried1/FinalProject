using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobSeekerService : IJobSeeker
    {
        IJobOffers jobOffersService;
        dbClass dataBase;
        public JobSeekerService(IJobOffers jobOffersService, dbClass dataBase)
        {
            this.jobOffersService = jobOffersService;
            this.dataBase = dataBase;
        }
        public bool AddJobSeeker(JobSeeker jobSeeker)
        {
            dataBase.JobSeekers.Add(jobSeeker);
            dataBase.SaveChanges();
            jobOffersService.AddJobs(jobSeeker);
            return false;
        }

        public List<Job> FindMatchingJobs(int jobId)
        {
            List<Job> jobMatches = new List<Job>();
            jobMatches = jobOffersService.FindMatchesById(jobId);
            return jobMatches;
        }

        public bool NotSeekingJob(int id)
        {
            foreach (JobOffer offer in dataBase.JobOffers)
            {
                if (offer.CandidateId == id)
                {
                    dataBase.JobOffers.Remove(offer);
                    dataBase.SaveChanges();
                }
            }
            if(dataBase.JobSeekers.FirstOrDefault(s => s.Id == id) != null)
            {
                dataBase.JobSeekers.Remove(dataBase.JobSeekers.FirstOrDefault(s => s.Id == id));
                dataBase.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
