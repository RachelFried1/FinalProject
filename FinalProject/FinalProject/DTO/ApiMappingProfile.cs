using AutoMapper;
using BL.Models;

namespace API.DTO
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<JobSeekerSignUpRequestDTO, JobSeekerBL>();
            CreateMap<CompanySignUpRequestDTO, CompanyBL>();
        }
    }
}
