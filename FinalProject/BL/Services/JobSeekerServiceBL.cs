using AutoMapper;
using BL.Api;
using BL.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class JobSeekerServiceBL : IJobSeekerBL
    {
        private IMapper _mapper;
        IDalManager _dalManager;

        public JobSeekerServiceBL(IMapper mapper, IDalManager dalManager)
        {
            _dalManager = dalManager;
            _mapper = mapper;
        }

        public JobSeekerBL GetJobSeekerById(int id)
        {
            return _mapper.Map<JobSeekerBL>(_dalManager.JobSeekerManager.GetJobSeekerById(id));
        }

        public void AddJobSeeker(JobSeekerBL jobSeekerBL)
        {
            JobSeeker jobSeeker = _mapper.Map<JobSeeker>(jobSeekerBL);
           _dalManager.JobSeekerManager.AddJobSeeker(jobSeeker);
        }
        public List<JobBL> FindMatchingJobs(int jobId)
        {
            return _mapper.Map<List<JobBL>>(_dalManager.JobSeekerManager.FindMatchingJobs(jobId));
        }

        //public void NotSeekingJob(int id)
        //{
        //    _dalManager.JobSeekerManager.NotSeekingJob(id);
        //}
    }
}
