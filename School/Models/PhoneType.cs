using System;
using System.Collections.Generic;

namespace School.Models;

public partial class PhoneType
{
    public int PhoneTypeId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
