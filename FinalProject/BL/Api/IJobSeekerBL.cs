using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IJobSeekerBL
    {
        bool AddJobSeeker(JobSeekerBL jobSeeker);
        List<JobBL> FindMatchingJobs(int jobId);
        bool NotSeekingJob(int id);
    }
}
