using DAL.Models.models;
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
        
        public int Code { get; set; }
        
        public int CompanyId { get; set; }
        public JobField Field { get; set; }
        public string Country { get; set; } = null!;
        public double WorkHours { get; set; }
        public int MinYearsExperience { get; set; }
        public bool RequiresDegree { get; set; }
        public string JobDescription { get; set; } = null!;
    }

}
