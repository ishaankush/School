using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Cource { get; set; } = null!;

    public double? CourceFee { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
