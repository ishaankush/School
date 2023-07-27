using System;
using System.Collections.Generic;

namespace School.Models;

public partial class UserMaster
{
    public int Uid { get; set; }

    public string? Name { get; set; }

    public string? UserId { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual Rolemaster? RoleNavigation { get; set; }
}
