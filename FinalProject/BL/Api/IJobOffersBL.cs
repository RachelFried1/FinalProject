using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IJobOffersBL
    {
        bool AddJobs(JobSeekerBL seeker);
        bool AddCandidates(JobBL job);
//        bool IsMatch(JobSeeker seeker, Job job);
        List<JobBL> FindMatchesById(int id);
        List<JobSeekerBL> FindCandidatesByJobCode(int jobCode);
    }
}
