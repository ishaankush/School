using System;
using System.Collections.Generic;

namespace School.Models;

public partial class NoticeBoard
{
    public int Id { get; set; }

    public string? NoticeBody { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
