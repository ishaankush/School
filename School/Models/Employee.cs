using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public int EmployeeTypeId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int? CountryId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual EmployeeType EmployeeType { get; set; } = null!;

    public virtual State? State { get; set; }
}
