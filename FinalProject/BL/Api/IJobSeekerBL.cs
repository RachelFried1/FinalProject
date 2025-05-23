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
        void AddJobSeeker(JobSeekerBL jobSeeker);
        List<JobBL> FindMatchingJobs(int jobId);
        List<JobOffer> GetJobOffersBySeekerId(int id);
        void Activate(int id);
        void NoLongerActive(int id);
        void ApplyForOffer(int offerCode);
    }
}
