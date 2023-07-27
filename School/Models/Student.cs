using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Class { get; set; } = null!;

    public DateTime Dob { get; set; }

    public int? CityId { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CourceId { get; set; }

    public DateTime AdmissionDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? FeePayment { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Course? Cource { get; set; }

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();

    public virtual State? State { get; set; }

    public virtual ICollection<StudentGuardian> StudentGuardians { get; set; } = new List<StudentGuardian>();
}
