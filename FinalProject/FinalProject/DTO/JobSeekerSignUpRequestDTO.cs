using BL.Models;

namespace API.DTO
{
    
    public class JobSeekerSignUpRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public double DailyWorkHours { get; set; }
        public int YearsOfExperience { get; set; }
        public bool HasDegree { get; set; }
        public JobField Field { get; set; }
        public string Password { get; set; }
    }
}
