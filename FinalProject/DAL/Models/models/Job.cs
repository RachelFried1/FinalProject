using System;
using System.Collections.Generic;

namespace FinalProject.models;

public partial class Job
{
    public int Code { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Field { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Country { get; set; } = null!;

    public double WorkHours { get; set; }

    public int MinYearsExperience { get; set; }

    public bool RequiresDegree { get; set; }

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
