using System;
using System.Collections.Generic;

namespace DAL.Models.models;

public partial class JobOffer
{
    public int OffersCode { get; set; }

    public int CandidateId { get; set; }

    public int JobCode { get; set; }

    public DateOnly Date { get; set; }

    public bool IsApplied { get; set; }

<<<<<<< HEAD
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
=======
    public DateTime? ApplicationDate { get; set; } = null;
>>>>>>> b30581dcf064fb04ced3d8fd221c8ae4a56cff17

    public double MatchingScore { get; set; }

    public virtual JobSeeker Candidate { get; set; } = null!;

    public virtual Job JobCodeNavigation { get; set; } = null!;
}
