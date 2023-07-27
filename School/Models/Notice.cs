using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Models;

public partial class Notice
{
    [Key]
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
