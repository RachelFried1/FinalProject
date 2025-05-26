using BL.Models;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IJobSeekerBL
    {
        JobSeekerBL GetJobSeekerById(int id);
        void AddJobSeeker(JobSeekerBL jobSeekerBL);
        //bool AddJobOffersForSeeker(JobSeekerBL jobSeekerBL);
        List<JobBL> GetJobOffersBySeekerId(int id);
        void Activate(int id);
        void NoLongerActive(int id);
        void ApplyForOffer(int offerCode);
    }
}
