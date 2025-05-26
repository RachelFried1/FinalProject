using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class JobSeekerBL
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string SirName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Country { get; set; } = null!;

        public double DailyWorkHours { get; set; }

        public int YearsOfExperience { get; set; }

        public bool HasDegree { get; set; }

        public string Field { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}
