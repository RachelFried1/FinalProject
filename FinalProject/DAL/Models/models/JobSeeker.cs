using System;
using System.Collections.Generic;

namespace FinalProject.models;

public partial class JobSeeker
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SirName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Country { get; set; } = null!;

    public double DailyWorkHours { get; set; }

    public int YearsOfExperience { get; set; }

    public bool HasDegree { get; set; }

    public string Field { get; set; } = null!;

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
