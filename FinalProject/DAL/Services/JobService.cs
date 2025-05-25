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
    public class JobService : IJob
    {
        
        dbClass dataBase;

        public JobService( dbClass dataBase)
        {
            
            this.dataBase = dataBase;
        }
        public Job GetJobByCode(int code)
        {
            Job job = dataBase.Jobs.FirstOrDefault(j => j.Code == code);
            if (job == null)
                throw new JobNotFoundException(code);
            return job;
        }
        public void AddJob(Job job)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == job.Code) != null)
               throw new JobAlreadyExistsException(job.Code);
            dataBase.Jobs.Add(job);
            dataBase.SaveChanges();
            AddJobOffersForJob(job);
        }
        public bool AddJobOffersForJob(Job job)
        {
            bool found = false;
            foreach (JobSeeker seeker in dataBase.JobSeekers)
            {
                if (seeker.IsActive && IsMatch(seeker, job))
                {
                    if (dataBase.JobOffers.FirstOrDefault(offer => offer.CandidateId == seeker.Id && offer.JobCode == job.Code) == null)
                    {
                        dataBase.JobOffers.Add(new JobOffer(job.Code, seeker.Id));
                        dataBase.SaveChanges();
                        found = true;
                    }
                }
            }
            return found;
        }

        private bool IsMatch(JobSeeker seeker, Job job)
        {
            if (seeker == null) return false;
            if (job == null) return false;
            if (seeker.Field != job.Field) return false;
            if (!seeker.HasDegree && job.RequiresDegree) return false;
            if (seeker.DailyWorkHours + 2 < job.WorkHours) return false;
            if (seeker.YearsOfExperience < job.MinYearsExperience) return false;
            return true;
        }
        public List<JobOffer> GetJobOffersByJobCode(int jobCode)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == jobCode) == null)
                throw new JobNotFoundException(jobCode);
            return dataBase.Jobs.FirstOrDefault(j => j.Code == jobCode).JobOffers.Where(offer => offer.Candidate.IsActive).ToList();
        }

        public List<JobOffer> GetActiveAppliedCandidatesByJobCode(int jobCode)
        {
            return GetJobOffersByJobCode(jobCode)
                .Where(offer => offer.Candidate.IsActive && offer.IsApplied)
                .ToList();
        }
        public List<Job> GetCompanyJobs(int companyCode)
        {
            if (dataBase.Companies.FirstOrDefault(c => c.Code == companyCode) == null)
            {
                throw new CompanyNotFoundException(companyCode);
            }
           return dataBase.Companies.FirstOrDefault(c=>c.Code == companyCode).Jobs.ToList();
        }

        public void NotSeekingWorkers(int code)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == code) == null)
               throw new JobNotFoundException(code);
            dataBase.Jobs.FirstOrDefault(j=>j.Code == code).JobOffers.Clear();
            dataBase.Jobs.Remove(dataBase.Jobs.FirstOrDefault(j => j.Code == code));
            dataBase.SaveChanges();
        }
    }
}
