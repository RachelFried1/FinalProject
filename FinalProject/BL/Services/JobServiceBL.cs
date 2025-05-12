using AutoMapper;
using BL.Api;
using BL.Models;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class JobServiceBL : IJobBL
    {
        private IMapper _mapper;
        IDalManager _dalManager;

        public JobServiceBL(IMapper mapper, IDalManager dalManager)
        {
            _dalManager = dalManager;
            _mapper = mapper;
        }

        public JobBL GetJobByCode(int code)
        {
            return _mapper.Map<JobBL>(_dalManager.JobManager.GetJobByCode(code));
        }

        public void AddJob(JobBL jobBl)
        {
            Job job = _mapper.Map<Job>(jobBl);
            _dalManager.JobManager.AddJob(job);
        }

        public List<JobSeekerBL> FindMatchingCandidates(int code)
        {
            return _mapper.Map<List<JobSeekerBL>>(_dalManager.JobManager.FindMatchingCandidates(code));
        }

        public void NotSeekingWorkers(int code)
        {
            _dalManager.JobManager.NotSeekingWorkers(code);
        }
    }
}
