using System;
using System.Collections.Generic;

namespace School.Models;

public partial class AddressType
{
    public string Name { get; set; } = null!;

    public int AddressTypeId { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
