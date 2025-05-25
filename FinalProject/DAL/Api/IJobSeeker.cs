using DAL.Exceptions;
using DAL.Models;
using DAL.Models.models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJobSeeker
    {
        JobSeeker GetJobSeekerById(int id);
        JobSeeker GetJobSeekerByEmail(string email);
        void AddJobSeeker(JobSeeker jobSeeker);
        bool AddJobOffersForSeeker(JobSeeker seeker);
        List<JobOffer> GetJobOffersBySeekerId(int id);
        void Activate(int id);
        void NoLongerActive(int id);

        void ApplyForOffer(int offerCode);
    }
}
