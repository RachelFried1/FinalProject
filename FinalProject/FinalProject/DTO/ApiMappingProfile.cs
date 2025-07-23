using AutoMapper;
using BL.Models;
using DAL.Models.models;

namespace API.DTO
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<JobSeekerSignUpRequestDTO, JobSeekerBL>();
            CreateMap<CompanySignUpRequestDTO, CompanyBL>();

        }
    }
}
