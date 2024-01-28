using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public string StaffType { get; set; } = null!;

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }
}
