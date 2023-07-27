using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? StudentId { get; set; }

    public int? EmployeeId { get; set; }

    public int AddressTypeId { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual Student? Student { get; set; }
}
