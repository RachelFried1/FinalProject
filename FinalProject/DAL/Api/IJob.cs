using DAL.Exceptions;
using DAL.Models.models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJob
    {
        Job GetJobByCode(int code);
        void AddJob(Job job);
        bool AddJobOffersForJob(Job job);
        List<JobOffer> GetJobOffersByJobCode(int jobCode);
        List<JobOffer> GetActiveAppliedCandidatesByJobCode(int jobCode);
        void NotSeekingWorkers(int code);
    }
}
