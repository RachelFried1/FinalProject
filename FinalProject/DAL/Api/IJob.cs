using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IJob
    {
        Job GetJobByCode(int code);
        void AddJob(Job job);
        ICollection<JobOffer> FindMatchingCandidates(int code);
        void NotSeekingWorkers(int code);
    }
}
