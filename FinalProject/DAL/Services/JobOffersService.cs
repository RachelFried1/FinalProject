using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobOffersService : IJobOffers
    {
        public List<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
        IDalManager _dalManager;
        public JobOffersService(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }
        public bool AddJobs(JobSeeker seeker)
        {
            bool found = false;
            foreach (Job job in _dalManager.JobManager.Jobs)
            {
                if (IsMatch(seeker, job))
                {
                    JobOffers.Add(new JobOffer(job, seeker));
                    found = true;
                }
            }
            return found;
        }
        public bool AddCandidates(Job job)
        {
            bool found = false;
            foreach (JobSeeker seeker in _dalManager.JobSeekerManager.JobSeekers)
            {
                if (IsMatch(seeker, job))
                {
                    JobOffers.Add(new JobOffer(job, seeker));
                    found = true;
                }
            }
            return found;
        }

        public bool IsMatch(JobSeeker seeker, Job job)
        {
            if (seeker == null) return false;
            if (job == null) return false;
            if (seeker.Field != job.Field) return false;
            if (!seeker.HasDegree && job.RequiresDegree) return false;
            if (seeker.DailyWorkHours + 2 < job.WorkHours) return false;
            if (seeker.YearsOfExperience < job.MinYearsExperience) return false;
            return true;
        }
        public List<Job> FindMatchesById(int id)
        {
            List<Job> jobMatches = new List<Job>();
            foreach (JobOffer offer in JobOffers)
            {
                if (offer.CandidateId == id)
                {
                    jobMatches.Add(offer.JobMatch);
                }
            }
            return jobMatches;
        }
        public List<JobSeeker> FindCandidatesByJobCode(int jobCode)
        {
            List<JobSeeker> candidates = new List<JobSeeker>();
            foreach (JobOffer offer in JobOffers)
            {
                if (offer.JobCode == jobCode)
                {
                    candidates.Add(offer.Candidate);
                }
            }
            return candidates;
        }

    }
}
