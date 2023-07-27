using System;
using System.Collections.Generic;

namespace School.Models;

public partial class State
{
    public int StateId { get; set; }

    public string? Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
