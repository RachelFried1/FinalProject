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
    public JobOffer(int jobCode, int candidateId, double matchingScore)
    {
        OffersCode = StaticCode++;
        JobCode = jobCode;
        CandidateId = candidateId;
        Date = DateOnly.FromDateTime(DateTime.Now);
        MatchingScore = matchingScore;
    }
}