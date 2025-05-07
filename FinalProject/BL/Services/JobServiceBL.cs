using BL.Api;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class JobServiceBL : IJobBL
    {
        public bool AddJob(JobBL job)
        {
            throw new NotImplementedException();
        }

        public List<JobSeekerBL> FindMatchingCandidates(int code)
        {
            throw new NotImplementedException();
        }

        public bool NotSeekingWorkers(int code)
        {
            throw new NotImplementedException();
        }
    }
}
