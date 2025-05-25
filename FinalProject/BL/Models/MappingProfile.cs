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
    }
}
