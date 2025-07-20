using System.ComponentModel.DataAnnotations;
using BL.Models;

namespace API.DTO
{
    public class JobSeekerSignUpRequestDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string SirName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Range(0, 24)]
        public double DailyWorkHours { get; set; }

        [Range(0, 100)]
        public int YearsOfExperience { get; set; }

        public bool HasDegree { get; set; }

        [Required]
        public JobField Field { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}