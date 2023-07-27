using System;
using System.Collections.Generic;

namespace School.Models;

public partial class EmployeeType
{
    public int EmployeeTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
