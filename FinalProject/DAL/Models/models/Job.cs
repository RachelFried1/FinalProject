using System;
using System.Collections.Generic;

namespace DAL.Models.models;

public partial class Job
{
    public int Code { get; set; }

    public int CompanyId { get; set; }

    public JobField Field { get; set; }

    public string Country { get; set; } = null!;

    public double WorkHours { get; set; }

    public int MinYearsExperience { get; set; }

    public bool RequiresDegree { get; set; }

    public string JobDescription { get; set; } = null!;
    public bool IsActive { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
