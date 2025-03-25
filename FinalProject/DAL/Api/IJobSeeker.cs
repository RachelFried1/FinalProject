using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJobSeeker
    {
        bool AddJobSeeker(JobSeeker jobSeeker);
        List<Job> FindMatchingJobs(int jobId);
        bool NotSeekingJob(int id);
    }
}
