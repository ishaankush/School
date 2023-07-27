using System;
using System.Collections.Generic;

namespace School.Models;

public partial class StudentAuditView
{
    public int AuditId { get; set; }

    public int? StudentId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string? OldName { get; set; }

    public string? NewName { get; set; }

    public string? OldClass { get; set; }

    public string? NewClass { get; set; }

    public DateTime? OldDob { get; set; }

    public DateTime? NewDob { get; set; }

    public int? OldCityId { get; set; }

    public int? NewCityId { get; set; }

    public int? OldCountryId { get; set; }

    public int? NewCountryId { get; set; }

    public int? OldStateId { get; set; }

    public int? NewStateId { get; set; }
}
