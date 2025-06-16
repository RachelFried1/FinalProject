using System;
using System.Collections.Generic;

namespace DAL.Models.models;

public partial class UserPassword
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string UserType { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual Company CompanyUser { get; set; } = null!;

    public virtual JobSeeker SeekerUser { get; set; } = null!;
}
