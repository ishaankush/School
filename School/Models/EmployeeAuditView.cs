using System;
using System.Collections.Generic;

namespace School.Models;

public partial class EmployeeAuditView
{
    public int AuditId { get; set; }

    public string? Operation { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string? OldName { get; set; }

    public string? NewName { get; set; }

    public int? OldEmployeeTypeId { get; set; }

    public int? NewEmployeeTypeId { get; set; }

    public int? OldStateId { get; set; }

    public int? NewStateId { get; set; }

    public int? OldCityId { get; set; }

    public int? NewCityId { get; set; }

    public int? OldCountryId { get; set; }

    public int? NewCountryId { get; set; }

    public int? OldSubjectId { get; set; }

    public int? NewSubjectId { get; set; }

    public int? OldPhoneId { get; set; }

    public int? NewPhoneId { get; set; }

    public int? OldEmailId { get; set; }

    public int? NewEmailId { get; set; }
}
