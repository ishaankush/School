using System;
using System.Collections.Generic;

namespace School.Models;

public partial class EmployeeDetailsView
{
    public string Employee { get; set; } = null!;

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string PhoneType { get; set; } = null!;

    public string EmployeeType { get; set; } = null!;

    public string? Locality { get; set; }

    public string? Colony { get; set; }

    public string? Zip { get; set; }
}
