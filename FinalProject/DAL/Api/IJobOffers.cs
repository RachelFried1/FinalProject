using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJobOffers
    {
        bool AddJobs(JobSeeker seeker);
        bool AddCandidates(Job job);
        bool IsMatch(JobSeeker seeker, Job job);
        List<Job> FindMatchesById(int id);
        List<JobSeeker> FindCandidatesByJobCode(int jobCode);
    }
}
