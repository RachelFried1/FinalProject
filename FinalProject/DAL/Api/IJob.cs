using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJob
    {
         bool AddJob(Job job);
         List<JobSeeker> FindMatchingCandidates(int code);
         bool NotSeekingWorkers(int code);
    }
}
