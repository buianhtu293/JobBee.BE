using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class CompanySize
{
    public Guid Id { get; set; }

    public string SizeRange { get; set; } = null!;

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
