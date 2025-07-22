using BL.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class AddJobDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Job code must be a positive integer.")]
        public int Code { get; set; }

        [Required]
        public JobField Field { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Country { get; set; } = null!;

        [Required]
        [Range(0.1, 24, ErrorMessage = "Work hours must be between 0.1 and 24.")]
        public double WorkHours { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Minimum years of experience must be between 0 and 100.")]
        public int MinYearsExperience { get; set; }

        [Required]
        public bool RequiresDegree { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string JobDescription { get; set; } = null!;
    }
}