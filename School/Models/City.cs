using System;
using System.Collections.Generic;

namespace School.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
