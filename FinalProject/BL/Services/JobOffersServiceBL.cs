using AutoMapper;
using BL.Api;
using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class JobOffersServiceBL : IJobOffersBL
    {
        private IMapper _mapper;
        IDalManager _dalManager;

        public JobOffersServiceBL(IMapper mapper, IDalManager dalManager)
        {
            _dalManager = dalManager;
            _mapper = mapper;
        }
        public List<JobSeekerBL> FindCandidatesByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobSeekerBL>>(_dalManager.JobOffersManager.FindCandidatesByJobCode(jobCode));
        }

        public List<JobBL> FindMatchesById(int id)
        {
            return _mapper.Map<List<JobBL>>(_dalManager.JobOffersManager.FindMatchesById(id));
        }
    }
}
