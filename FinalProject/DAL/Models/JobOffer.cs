using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.models;
public partial class JobOffer
{
    private static int StaticCode = 0;
<<<<<<< HEAD
    public JobOffer(int jobCode, int candidateId,double matchingScore)
=======
    public JobOffer(int jobCode, int candidateId, double matchingScore)
>>>>>>> 5b2ee4eb27a5ae6e0701273b23e05412b50583ff
    {
        OffersCode = StaticCode++;
        JobCode = jobCode;
        CandidateId = candidateId;
        Date = DateOnly.FromDateTime(DateTime.Now);
        MatchingScore = matchingScore;
    }
}