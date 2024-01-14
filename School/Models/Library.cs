using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Models;

public partial class Library
{
    [Key]
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? AuthorName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? StudentId { get; set; }
}
