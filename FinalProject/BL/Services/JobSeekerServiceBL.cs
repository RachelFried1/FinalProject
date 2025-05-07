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

        public bool AddJobSeeker(JobSeekerBL jobSeekerBL)
        {
            JobSeeker jobSeeker = _mapper.Map<JobSeeker>(jobSeekerBL);
            return _dalManager.JobSeekerManager.AddJobSeeker(jobSeeker);
        }
        public List<JobBL> FindMatchingJobs(int jobId)
        {
            throw new NotImplementedException();
        }

        public bool NotSeekingJob(int id)
        {
            throw new NotImplementedException();
        }
    }
}
