using System;
using System.Collections.Generic;

namespace School.Models;

public partial class GaurdianType
{
    public int GuardianTypeId { get; set; }

    public string? Name { get; set; }

    public string GuardianType { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual ICollection<StudentGuardian> StudentGuardians { get; set; } = new List<StudentGuardian>();
}
