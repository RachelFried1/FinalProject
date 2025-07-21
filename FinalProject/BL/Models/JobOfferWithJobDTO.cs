using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class JobOfferWithJobDTO
    {
        public int OffersCode { get; set; }
        public int JobCode { get; set; }
        public double MatchingScore { get; set; }
        public bool IsApplied { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int JobCompanyId { get; set; }
        public JobField JobField { get; set; }
        public string JobCountry { get; set; } = null!;
        public double JobWorkHours { get; set; }
        public int JobMinYearsExperience { get; set; }
        public bool JobRequiresDegree { get; set; }
        public string JobDescription { get; set; } = null!;
    }
}
