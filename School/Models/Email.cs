using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Email
{
    public int EmailId { get; set; }

    public string Email1 { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int? StudentId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual Student? Student { get; set; }
}
