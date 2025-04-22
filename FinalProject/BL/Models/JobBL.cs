using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class JobBL
    {
        public int Code { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Field { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Country { get; set; } = null!;
        public double WorkHours { get; set; }
        public int MinYearsExperience { get; set; }
        public bool RequiresDegree { get; set; }
    }
}
