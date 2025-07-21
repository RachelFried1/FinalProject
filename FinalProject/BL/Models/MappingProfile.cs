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
    }
}
