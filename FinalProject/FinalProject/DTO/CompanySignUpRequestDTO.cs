using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class CompanySignUpRequestDTO
    {
        [Required]
        public int Code { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Range(0, 5)]
        public int Rate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}