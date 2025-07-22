using AutoMapper;
using BL.Models;
using DAL.Models;
using DAL.Models.models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobSeekerBL, JobSeeker>();
        CreateMap<JobSeeker, JobSeekerBL>();
        CreateMap<JobBL,Job>();
        CreateMap<Job,JobBL>();
        CreateMap<CompanyBL, Company>();
        CreateMap<Company, CompanyBL>();
        CreateMap<JobOfferBL, JobOffer>();
        CreateMap<JobOffer, JobOfferBL>();
        CreateMap<JobOffer, CompanyBL>();
        CreateMap<JobOffer, JobOfferWithCandidateDTO>()
            .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.Candidate.Id))
            .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => src.Candidate.Name))
            .ForMember(dest => dest.CandidateSirName, opt => opt.MapFrom(src => src.Candidate.SirName))
            .ForMember(dest => dest.CandidateEmail, opt => opt.MapFrom(src => src.Candidate.Email))
            .ForMember(dest => dest.CandidateCountry, opt => opt.MapFrom(src => src.Candidate.Country))
            .ForMember(dest => dest.CandidateYearsOfExperience, opt => opt.MapFrom(src => src.Candidate.YearsOfExperience))
            .ForMember(dest => dest.CandidateDailyWorkHours, opt => opt.MapFrom(src => src.Candidate.DailyWorkHours))
            .ForMember(dest => dest.CandidateHasDegree, opt => opt.MapFrom(src => src.Candidate.HasDegree))
            .ForMember(dest => dest.CandidateField, opt => opt.MapFrom(src => (BL.Models.JobField)src.Candidate.Field));
        CreateMap<JobOffer, JobOfferWithJobDTO>()
           .ForMember(dest => dest.JobCompanyId, opt => opt.MapFrom(src => src.JobCodeNavigation.CompanyId))
           .ForMember(dest => dest.JobField, opt => opt.MapFrom(src => (BL.Models.JobField)src.JobCodeNavigation.Field))
           .ForMember(dest => dest.JobCountry, opt => opt.MapFrom(src => src.JobCodeNavigation.Country))
           .ForMember(dest => dest.JobWorkHours, opt => opt.MapFrom(src => src.JobCodeNavigation.WorkHours))
           .ForMember(dest => dest.JobMinYearsExperience, opt => opt.MapFrom(src => src.JobCodeNavigation.MinYearsExperience))
           .ForMember(dest => dest.JobRequiresDegree, opt => opt.MapFrom(src => src.JobCodeNavigation.RequiresDegree))
           .ForMember(dest => dest.JobDescription, opt => opt.MapFrom(src => src.JobCodeNavigation.JobDescription));

    }
}
