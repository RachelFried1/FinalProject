using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public partial class JobOffer
    {
        private static int StaticCode = 0;
        public JobOffer(Job job, JobSeeker candidate)
        {
            OffersCode = StaticCode++;
            JobMatch = job;
            Candidate = candidate;
            Date = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
