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
            if (dataBase.JobSeekers.Contains(jobSeeker))
                return false;
            dataBase.JobSeekers.Add(jobSeeker);
            dataBase.SaveChanges();
            jobOffersService.AddJobs(jobSeeker);
            return true;
        }

        public ICollection<JobOffer> FindMatchingJobs(int jobId)
        {
            return jobOffersService.FindMatchesById(jobId);
        }

        public bool NotSeekingJob(int id)
        {
            if (dataBase.JobSeekers.FirstOrDefault(s => s.Id == id) != null)
            {
                dataBase.JobSeekers.FirstOrDefault(s => s.Id == id).JobOffers.Clear();
                dataBase.Remove(dataBase.JobSeekers.FirstOrDefault(s => s.Id == id));
                dataBase.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
