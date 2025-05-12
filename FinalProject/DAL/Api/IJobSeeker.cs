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
        JobSeeker GetJobSeekerById(int id);
        void AddJobSeeker(JobSeeker jobSeeker);
        ICollection<JobOffer> FindMatchingJobs(int jobId);
        void NotSeekingJob(int id);
    }
}
