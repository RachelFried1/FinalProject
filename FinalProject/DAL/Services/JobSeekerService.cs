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
    public class JobSeekerService : IJobSeeker
    {

        dbClass dataBase;
        public JobSeekerService(dbClass dataBase)
        {
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
            jobSeeker.IsActive = true;
            dataBase.JobSeekers.Add(jobSeeker);
            dataBase.SaveChanges();
            AddJobOffersForSeeker(jobSeeker);
        }
        public bool AddJobOffersForSeeker(JobSeeker seeker)
        {
            bool found = false;
            foreach (Job job in dataBase.Jobs)
            {
                if (IsMatch(seeker, job))
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
            dataBase.JobSeekers.FirstOrDefault(s => s.Id == id).IsActive = true;
            dataBase.SaveChanges();

        }
        public void NoLongerActive(int id)
        {
            var jobSeeker = dataBase.JobSeekers.FirstOrDefault(s => s.Id == id);
            if (jobSeeker == null)
                throw new SeekerNotFoundException(id);
            if (!jobSeeker.IsActive)
                throw new SeekerNotActiveException(id);
            dataBase.JobSeekers.FirstOrDefault(s => s.Id == id).IsActive = false;
            dataBase.SaveChanges();
        }

        public void ApplyForOffer(int offerCode)
        {
            var jobOffer = dataBase.JobOffers.FirstOrDefault(offer => offer.OffersCode == offerCode);
            if (jobOffer == null)
                throw new OfferNotFoundException(offerCode);
            if (jobOffer.IsApplied)
                throw new SeekerAlreadyAppliedException(offerCode);
            dataBase.JobOffers.FirstOrDefault(offer => offer.OffersCode == offerCode).IsApplied = true;
            dataBase.JobOffers.FirstOrDefault(offer => offer.OffersCode == offerCode).ApplicationDate = DateTime.Now;
            dataBase.SaveChanges();
        }

    }
}
