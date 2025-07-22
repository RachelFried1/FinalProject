using AutoMapper;
using BL.Api;
using BL.Models;
using DAL;
using DAL.Exceptions;
using DAL.Models;
using DAL.Models.models;
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

        public List<JobOfferBL> GetJobOffersBySeekerId(int id)
        {
            return _mapper.Map<List<JobOfferBL>>(_dalManager.JobSeekerManager.GetJobOffersBySeekerId(id));
        }

        public List<JobOfferWithJobDTO> GetJobOffersWithJobsBySeekerId(int id)
        {
            var jobOffers = _dalManager.JobSeekerManager.GetJobOffersBySeekerId(id);
            return _mapper.Map<List<JobOfferWithJobDTO>>(jobOffers);
        }
        public void Activate(int id)
        {
            _dalManager.JobSeekerManager.Activate(id);

        }
        public void NoLongerActive(int id)
        {
            _dalManager.JobSeekerManager.NoLongerActive(id);
        }

        public void ApplyForOffer(int offerCode)
        {
            _dalManager.JobSeekerManager.ApplyForOffer(offerCode);
        }
    }
}
