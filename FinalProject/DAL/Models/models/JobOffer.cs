using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class JobOffer
{
    public int OffersCode { get; set; }

    public int CandidateId { get; set; }

    public int JobCode { get; set; }

    public DateOnly Date { get; set; }

    public virtual JobSeeker Candidate { get; set; } = null!;

    public virtual Job JobMatch { get; set; } = null!;

   
}
