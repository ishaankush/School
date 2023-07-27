using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public int? EmployeeId { get; set; }

    public int? CourceId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual Course? Cource { get; set; }
}
