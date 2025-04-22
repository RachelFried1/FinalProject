using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IJobSeekerBL
    {
        bool AddJobSeeker(JobSeeker jobSeeker);
        List<Job> FindMatchingJobs(int jobId);
        bool NotSeekingJob(int id);
    }
}
