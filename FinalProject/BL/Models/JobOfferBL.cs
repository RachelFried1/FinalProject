using DAL.Models;
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class JobOfferBL
    {
        public int OffersCode { get; set; }

        public int CandidateId { get; set; }

        public int JobCode { get; set; }

        public DateOnly Date { get; set; }

        public bool IsApplied { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}
