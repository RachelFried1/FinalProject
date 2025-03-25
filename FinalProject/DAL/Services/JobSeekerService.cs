using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobSeekerService: IJobSeeker
    {
        public List<JobSeeker> JobSeekers { get; set; }

        IDalManager _dalManager;
        public JobSeekerService(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }
        public bool AddJobSeeker(JobSeeker jobSeeker)
        {
            JobSeekers.Add(jobSeeker);
            _dalManager.JobOffersManager.AddJobs(jobSeeker);
            return false;
        }

        public List<Job> FindMatchingJobs(int jobId)
        {
            List<Job> jobMatches = new List<Job>();
            jobMatches = _dalManager.JobOffersManager.FindMatchesById(jobId);
            return jobMatches;
        }

        public bool NotSeekingJob(int id)
        {
            foreach (JobOffer offer in _dalManager.JobOffersManager.JobOffers)
            {
                if (offer.CandidateId == id)
                {
                    _dalManager.JobOffersManager.JobOffers.Remove(offer);
                }
            }
            return JobSeekers.Remove(JobSeekers.FirstOrDefault(s => s.Id == id));
        }
    }
}
