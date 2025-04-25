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
        public JobOffer(int jobCode, int candidateId)
        {
            OffersCode = StaticCode++;
            JobCode = jobCode;
            CandidateId = candidateId;
            Date = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
