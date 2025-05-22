using DAL.Models.models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJobOffers
    {
        bool AddJobs(JobSeeker seeker);
        bool AddCandidates(Job job);
        bool IsMatch(JobSeeker seeker, Job job);
        List<JobOffer> FindMatchesById(int id);
        List<JobOffer> GetActiveAppliedCandidatesByJobCode(int jobCode);
        List<JobOffer> FindOffersByJobCode(int jobCode);
    }
}
