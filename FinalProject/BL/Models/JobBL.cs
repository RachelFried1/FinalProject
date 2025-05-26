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
        [Required]
        public int Code { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public string Field { get; set; } = null!;
        public string Country { get; set; } = null!;
        public double WorkHours { get; set; }
        public int MinYearsExperience { get; set; }
        public bool RequiresDegree { get; set; }
        public string JobDescription { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        //public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }

}
