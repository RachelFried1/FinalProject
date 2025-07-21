using BL.Models;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IJobBL
    {
        JobBL GetJobByCode(int code);
        void AddJob(JobBL jobBl);      
        List<JobOfferBL> GetJobOffersByJobCode(int jobCode);
        List<JobOfferWithCandidateDTO> GetJobOffersWithCandidatesByJobCode(int jobCode);
        List<JobOfferBL> GetAppliedCandidatesByJobCode(int jobCode);
        List<JobOfferWithCandidateDTO> GetAppliedCandidatesWithCandidatesByJobCode(int jobCode);
        List<JobBL> GetCompanyJobs(int companyCode);
        void NotSeekingWorkers(int code);
    }
}
