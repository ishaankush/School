using System;
using System.Collections.Generic;

namespace School.Models;

public partial class StudentGuardian
{
    public int GuardianId { get; set; }

    public string GuardianName { get; set; } = null!;

    public int? StudentId { get; set; }

    public int GuardianTypeId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<GaurdianPhone> GaurdianPhones { get; set; } = new List<GaurdianPhone>();

    public virtual GaurdianType GuardianType { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
