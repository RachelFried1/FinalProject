using AutoMapper;
using BL.Models;
using DAL.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobSeekerBL, JobSeeker>();
        CreateMap<JobSeeker, JobSeekerBL>();
    }
}
