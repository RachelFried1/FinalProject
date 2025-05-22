using DAL.Api;
using DAL.Exceptions;
using DAL.Models;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobOffersService : IJobOffers
    {
        dbClass dataBase;
        public JobOffersService(dbClass dataBase)
        {
            this.dataBase = dataBase;
        }
        //AddJobOffersForSeeker
        public bool AddJobs(JobSeeker seeker)
        {
            bool found = false;
            foreach (Job job in dataBase.Jobs)
            {
                if (IsMatch(seeker, job))
                {
                    dataBase.JobOffers.Add(new JobOffer(job.Code, seeker.Id));
                    dataBase.SaveChanges();
                    found = true;
                }
            }
            return found;
        }
        // AddJobOffersForJob
        public bool AddCandidates(Job job)
        {
            bool found = false;
            foreach (JobSeeker seeker in dataBase.JobSeekers)
            {
                if (IsMatch(seeker, job))
                {
                    dataBase.JobOffers.Add(new JobOffer(job.Code, seeker.Id));
                    dataBase.SaveChanges();
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
        //GetJobOffersBySeekerId
        public List<JobOffer> FindMatchesById(int id)
        {
            if (dataBase.JobSeekers.FirstOrDefault(s => s.Id == id) == null)
                throw new SeekerNotFoundException(id);
            return dataBase.JobSeekers.FirstOrDefault(s => s.Id == id).JobOffers.ToList();
        }
        //GetJobOffersByJobCode
        public List<JobOffer> FindOffersByJobCode(int jobCode)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == jobCode) == null)
                throw new JobNotFoundException(jobCode);
            return dataBase.Jobs.FirstOrDefault(j => j.Code == jobCode).JobOffers.ToList();
        }

        //GetActiveAppliedCandidatesByJobCode
        //public List<JobOffer> FindCandidatesByJobCode(int jobCode)
        //{
        //    List<JobOffer> allOffers = FindOffersByJobCode(jobCode);
        //    List<JobOffer> candidates = new List<JobOffer>();
        //    foreach (JobOffer offer in allOffers)
        //    {
        //        if (offer.Candidate.IsActive && offer.IsApplied)
        //        {
        //            candidates.Add(offer);
        //        }
        //    }
        //    return candidates;
        //}

        public List<JobOffer> GetActiveAppliedCandidatesByJobCode(int jobCode)
        {
            return FindOffersByJobCode(jobCode)
                .Where(offer => offer.Candidate.IsActive && offer.IsApplied)
                .ToList();
        }

    }
}
