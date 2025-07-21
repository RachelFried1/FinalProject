using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class JobOfferWithCandidateDTO
    {
        public int OffersCode { get; set; }
        public int JobCode { get; set; }
        public double MatchingScore { get; set; }
        public bool IsApplied { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateSirName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateCountry { get; set; }
        public int CandidateYearsOfExperience { get; set; }
        public double CandidateDailyWorkHours { get; set; }
        public bool CandidateHasDegree { get; set; }
        public JobField CandidateField { get; set; }
    }
}
