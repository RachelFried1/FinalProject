using DAL.Api;
using DAL.Exceptions;
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

        public JobSeeker GetJobSeekerById(int id)
        {
            var jobSeeker = dataBase.JobSeekers.FirstOrDefault(s => s.Id == id);
            if (jobSeeker == null)
                throw new SeekerNotFoundException(id);
            return jobSeeker;
        }
        public void AddJobSeeker(JobSeeker jobSeeker)
        {
            if (dataBase.JobSeekers.Contains(jobSeeker))
                throw new SeekerAlreadyExistsException(jobSeeker.Id);
            dataBase.JobSeekers.Add(jobSeeker);
            dataBase.SaveChanges();
            jobOffersService.AddJobs(jobSeeker);
        }

        public ICollection<JobOffer> FindMatchingJobs(int jobId)
        {
            return jobOffersService.FindMatchesById(jobId);
        }

        //public void NotSeekingJob(int id)
        //{
        //    if (dataBase.JobSeekers.FirstOrDefault(s => s.Id == id) != null)
        //    {
        //        dataBase.JobSeekers.FirstOrDefault(s => s.Id == id).JobOffers.Clear();
        //        dataBase.SaveChanges();
        //    }
        //    else throw new SeekerNotFoundException(id);
        //}
    }
}
