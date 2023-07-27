using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Rolemaster
{
    public int RoleId { get; set; }

    public string? RoleDescription { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<UserMaster> UserMasters { get; set; } = new List<UserMaster>();
}
