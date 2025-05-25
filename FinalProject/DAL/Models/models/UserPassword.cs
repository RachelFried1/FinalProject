using System;
using System.Collections.Generic;

namespace DAL.Models.models;

public partial class UserPassword
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string UserType { get; set; } = null!; // "JobSeeker" or "Company"

    public string PasswordHash { get; set; } = null!;

    // One-to-one relationship with Company
    public virtual Company? Company { get; set; }

    // One-to-one relationship with JobSeeker
    public virtual JobSeeker? JobSeeker { get; set; }
}
