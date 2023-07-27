using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Phone
{
    public int PhoneId { get; set; }

    public int? EmployeeId { get; set; }

    public int? StudentId { get; set; }

    public int PhoneTypeId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual PhoneType PhoneType { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
