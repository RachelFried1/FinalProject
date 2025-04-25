using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class JobBL
    {
        [Required]
        public int Code { get; set; }
        [Required]
        public string CompanyName { get; set; } = null!;
        public string Field { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Country { get; set; } = null!;
        public double WorkHours { get; set; }
        public int MinYearsExperience { get; set; }
        public bool RequiresDegree { get; set; }
    }
}
