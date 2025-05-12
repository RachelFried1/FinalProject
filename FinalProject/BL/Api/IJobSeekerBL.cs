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
        JobSeekerBL GetJobSeekerById(int id);
        void AddJobSeeker(JobSeekerBL jobSeeker);
        List<JobBL> FindMatchingJobs(int jobId);
        void NotSeekingJob(int id);
    }
}
