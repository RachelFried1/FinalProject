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
using DAL.Models.models;

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

        //public List<JobSeekerBL> FindMatchingCandidates(int code)
        //{
        //    return _mapper.Map<List<JobSeekerBL>>(_dalManager.JobManager.FindMatchingCandidates(code));
        //}

        

        //public bool AddJobOffersForJob(Job job)
        //{
        //    return _dalManager.JobManager.AddJobOffersForJob(_mapper.Map<Job>(job));
        //}

        public void NotSeekingWorkers(int code)
        {
            _dalManager.JobManager.NotSeekingWorkers(code);
        }

        public List<JobSeekerBL> GetJobOffersByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobSeekerBL>>(_dalManager.JobManager.GetJobOffersByJobCode(jobCode));
        }
        public List<JobOfferBL> GetAppliedCandidatesByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobOfferBL>>(_dalManager.JobManager.GetActiveAppliedCandidatesByJobCode(jobCode));
        }
    }
}
