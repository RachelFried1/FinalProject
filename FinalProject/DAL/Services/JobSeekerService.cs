using DAL.Api;
using DAL.Exceptions;
using DAL.Models.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    public class JobSeekerService : IJobSeeker
    {
        dbClass dataBase;

        public JobSeekerService(dbClass dataBase)
        {
            this.dataBase = dataBase;
        }

        public JobSeeker GetJobSeekerById(int id)
        {
            return dataBase.JobSeekers
                .Include(s => s.UserPassword)
                .FirstOrDefault(s => s.Id == id);
        }

        public JobSeeker GetJobSeekerByEmail(string email)
        {
            var jobSeeker = dataBase.JobSeekers
                .Include(s => s.UserPassword)
                .FirstOrDefault(s => s.Email == email);
            return jobSeeker;
        }

        public void AddJobSeeker(JobSeeker jobSeeker)
        {
            if (dataBase.JobSeekers.Any(s => s.Id == jobSeeker.Id))
                throw new SeekerAlreadyExistsException(jobSeeker.Id);
            jobSeeker.IsActive = true;
            dataBase.JobSeekers.Add(jobSeeker);
            dataBase.SaveChanges();
            AddJobOffersForSeeker(jobSeeker);
        }
        public bool AddJobOffersForSeeker(JobSeeker seeker)
        {
            bool found = false;
            MatchingService matchService = new MatchingService();
            foreach (Job job in dataBase.Jobs)
            {
                double matchScore = matchService.CalculateMatchingScore(seeker, job);
                if (matchScore >= 0.7)
                {
                    var existingOffer = dataBase.JobOffers.FirstOrDefault(offer => offer.CandidateId == seeker.Id && offer.JobCode == job.Code);
                    if (existingOffer == null)
                    {
                        JobOffer offer = new JobOffer(seeker.Id, job.Code, matchScore);
                        dataBase.JobOffers.Add(offer);
                        dataBase.SaveChanges();
                        found = true;
                    }
                }
            }
            return found;
        }

        public List<JobOffer> GetJobOffersBySeekerId(int id)
        {
            if (dataBase.JobSeekers.FirstOrDefault(s => s.Id == id) == null)
                throw new SeekerNotFoundException(id);
            return dataBase.JobSeekers.FirstOrDefault(s => s.Id == id).JobOffers.ToList();
        }

        public void Activate(int id)
        {
            var jobSeeker = dataBase.JobSeekers.FirstOrDefault(s => s.Id == id);
            if (jobSeeker == null)
                throw new SeekerNotFoundException(id);
            if (jobSeeker.IsActive)
                throw new SeekerAlreadyActiveException(id);
            jobSeeker.IsActive = true;
            dataBase.SaveChanges();
        }

        public void NoLongerActive(int id)
        {
            var jobSeeker = dataBase.JobSeekers.FirstOrDefault(s => s.Id == id);
            if (jobSeeker == null)
                throw new SeekerNotFoundException(id);
            if (!jobSeeker.IsActive)
                throw new SeekerNotActiveException(id);
            jobSeeker.IsActive = false;
            dataBase.SaveChanges();
        }

        public void ApplyForOffer(int offerCode)
        {
            var jobOffer = dataBase.JobOffers.FirstOrDefault(offer => offer.OffersCode == offerCode);
            if (jobOffer == null)
                throw new OfferNotFoundException(offerCode);
            if (jobOffer.IsApplied)
                throw new SeekerAlreadyAppliedException(offerCode);
            jobOffer.IsApplied = true;
            jobOffer.ApplicationDate = DateTime.Now;
            dataBase.SaveChanges();
        }
    }
}