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
        public List<JobOfferBL> GetJobOffersByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobOfferBL>>(_dalManager.JobManager.GetJobOffersByJobCode(jobCode));
        }
        public List<JobOfferWithCandidateDTO> GetJobOffersWithCandidatesByJobCode(int jobCode)
        {
            var jobOffers = _dalManager.JobManager.GetJobOffersByJobCode(jobCode);

            return jobOffers.Select(offer => new JobOfferWithCandidateDTO
            {
                OffersCode = offer.OffersCode,
                JobCode = offer.JobCode,
                MatchingScore = offer.MatchingScore,
                IsApplied = offer.IsApplied,
                ApplicationDate = offer.ApplicationDate,
                CandidateId = offer.Candidate.Id,
                CandidateName = offer.Candidate.Name,
                CandidateSirName = offer.Candidate.SirName,
                CandidateEmail = offer.Candidate.Email,
                CandidateCountry = offer.Candidate.Country,
                CandidateYearsOfExperience = offer.Candidate.YearsOfExperience,
                CandidateDailyWorkHours = offer.Candidate.DailyWorkHours,
                CandidateHasDegree = offer.Candidate.HasDegree,
                CandidateField = (Models.JobField)offer.Candidate.Field
            }).ToList();
        }
        public List<JobOfferBL> GetAppliedCandidatesByJobCode(int jobCode)
        {
            return _mapper.Map<List<JobOfferBL>>(_dalManager.JobManager.GetActiveAppliedCandidatesByJobCode(jobCode));
        }

        public List<JobOfferWithCandidateDTO> GetAppliedCandidatesWithCandidatesByJobCode(int jobCode)
        {
            var jobOffers = _dalManager.JobManager.GetActiveAppliedCandidatesByJobCode(jobCode);

            return jobOffers.Select(offer => new JobOfferWithCandidateDTO
            {
                OffersCode = offer.OffersCode,
                JobCode = offer.JobCode,
                MatchingScore = offer.MatchingScore,
                IsApplied = offer.IsApplied,
                ApplicationDate = offer.ApplicationDate,
                CandidateId = offer.Candidate.Id,
                CandidateName = offer.Candidate.Name,
                CandidateSirName = offer.Candidate.SirName,
                CandidateEmail = offer.Candidate.Email,
                CandidateCountry = offer.Candidate.Country,
                CandidateYearsOfExperience = offer.Candidate.YearsOfExperience,
                CandidateDailyWorkHours = offer.Candidate.DailyWorkHours,
                CandidateHasDegree = offer.Candidate.HasDegree,
                CandidateField = (Models.JobField)offer.Candidate.Field
            }).ToList();
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
