using System;
using System.Collections.Generic;

namespace DAL.Models.models;

public partial class Company
{
    public int Code { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Rate { get; set; }
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual CompanyPassword? UserPassword { get; set; }
}
