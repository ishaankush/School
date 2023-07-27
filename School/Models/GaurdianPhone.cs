using System;
using System.Collections.Generic;

namespace School.Models;

public partial class GaurdianPhone
{
    public int GuardianPhoneId { get; set; }

    public int? GuardianId { get; set; }

    public string GuardianPhone { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual StudentGuardian? Guardian { get; set; }
}
