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
using DAL.Exceptions;

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
            _dalManager.JobManager.AddJob(_mapper.Map<Job>(jobBl));
        }
        //public bool AddJobOffersForJob(JobBL jobBl)
        //{
        //    return _dalManager.JobManager.AddJobOffersForJob(_mapper.Map<Job>(jobBl));
        //}
       

        public List<JobSeekerBL> GetJobOffersByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobSeekerBL>>(_dalManager.JobManager.GetJobOffersByJobCode(jobCode));
        }
        public List<JobOfferBL> GetAppliedCandidatesByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobOfferBL>>(_dalManager.JobManager.GetActiveAppliedCandidatesByJobCode(jobCode));
        }
        public List<JobBL> GetCompanyJobs(int companyCode)
        {
            return _mapper.Map<List<JobBL>>(_dalManager.JobManager.GetCompanyJobs(companyCode));
        }
        public void NotSeekingWorkers(int code)
        {
            _dalManager.JobManager.NotSeekingWorkers(code);
        }
    }
}
