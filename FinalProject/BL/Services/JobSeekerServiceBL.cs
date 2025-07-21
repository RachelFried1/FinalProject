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

            return jobOffers.Select(offer => new JobOfferWithJobDTO
            {
                OffersCode = offer.OffersCode,
                JobCode = offer.JobCode,
                MatchingScore = offer.MatchingScore,
                IsApplied = offer.IsApplied,
                ApplicationDate = offer.ApplicationDate,
                JobCompanyId = offer.JobCodeNavigation.CompanyId,
                JobField = (Models.JobField)offer.JobCodeNavigation.Field,
                JobCountry = offer.JobCodeNavigation.Country,
                JobWorkHours = offer.JobCodeNavigation.WorkHours,
                JobMinYearsExperience = offer.JobCodeNavigation.MinYearsExperience,
                JobRequiresDegree = offer.JobCodeNavigation.RequiresDegree,
                JobDescription = offer.JobCodeNavigation.JobDescription
            }).ToList();
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
