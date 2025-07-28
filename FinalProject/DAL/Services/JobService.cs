using DAL.Api;
using DAL.Exceptions;
using DAL.Models;
using DAL.Models.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            return dataBase.Jobs.FirstOrDefault(j => j.Code == code);
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
            MatchingService matchService = new MatchingService();
            foreach (JobSeeker seeker in dataBase.JobSeekers)
            {

                if (seeker.IsActive)
                {
                    double score = matchService.CalculateMatchingScore(seeker, job);
                    if (score >= 0.4)
                    {
                        if (dataBase.JobOffers.FirstOrDefault(offer => offer.CandidateId == seeker.Id && offer.JobCode == job.Code) == null)
                        {
                            dataBase.JobOffers.Add(new JobOffer(job.Code, seeker.Id, score));
                            dataBase.SaveChanges();
                            found = true;
                        }
                    }
                }
            }
            return found;
        }

        public List<JobOffer> GetJobOffersByJobCode(int jobCode)
{
            var job = dataBase.Jobs
                .Include(j => j.JobOffers)
                    .ThenInclude(offer => offer.Candidate)
                .FirstOrDefault(j => j.Code == jobCode);

            if (job == null)
                throw new JobNotFoundException(jobCode);

            return job.JobOffers
                .Where(offer => offer.Candidate != null && offer.Candidate.IsActive)
                .ToList();
        }

        public List<JobOffer> GetActiveAppliedCandidatesByJobCode(int jobCode)
        {
            var jobOffers = dataBase.JobOffers
                .Include(offer => offer.Candidate)
                .Include(offer => offer.JobCodeNavigation)
                .Where(offer => offer.JobCode == jobCode && offer.Candidate.IsActive && offer.IsApplied)
                .ToList();

            return jobOffers;
        }

        public List<Job> GetCompanyJobs(int companyCode)
        {
            var company = dataBase.Companies
                .Include(c => c.Jobs)
                .FirstOrDefault(c => c.Code == companyCode);

            if (company == null)
                throw new CompanyNotFoundException(companyCode);

            return company.Jobs.ToList();
        }

        public void NotSeekingWorkers(int code)
        {
            var job = dataBase.Jobs
                .Include(j => j.JobOffers)
                .FirstOrDefault(j => j.Code == code);

            if (job == null)
                throw new JobNotFoundException(code);
            dataBase.JobOffers.RemoveRange(job.JobOffers);
            dataBase.Jobs.Remove(job);
            dataBase.SaveChanges();
        }
    }
}
