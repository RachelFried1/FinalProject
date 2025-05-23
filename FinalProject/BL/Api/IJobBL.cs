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
        void AddJob(JobBL job);
        List<JobSeekerBL> FindMatchingCandidates(int code);
        void NotSeekingWorkers(int code);
        List<JobOffer> GetActiveAppliedCandidatesByJobCode(int jobCode);
    }
}
