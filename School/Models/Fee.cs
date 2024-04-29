using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Fee
{
    public int FeesId { get; set; }

    public int? StudentId { get; set; }

    public bool? January { get; set; }

    public bool? February { get; set; }

    public bool? March { get; set; }

    public bool? April { get; set; }

    public bool? May { get; set; }

    public bool? June { get; set; }

    public bool? July { get; set; }

    public bool? August { get; set; }

    public bool? September { get; set; }

    public bool? October { get; set; }

    public bool? Novemeber { get; set; }

    public bool? December { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? ModifiedBy { get; set; }

    public virtual Student? Student { get; set; }
}
