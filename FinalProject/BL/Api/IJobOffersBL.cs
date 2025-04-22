using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IJobOffersBL
    {
        bool AddJobs(JobSeeker seeker);
        bool AddCandidates(Job job);
        bool IsMatch(JobSeeker seeker, Job job);
        List<Job> FindMatchesById(int id);
        List<JobSeeker> FindCandidatesByJobCode(int jobCode);
    }
}
