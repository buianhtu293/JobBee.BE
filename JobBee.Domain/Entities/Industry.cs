using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class Industry
{
    public Guid Id { get; set; }

    public string IndustryName { get; set; } = null!;

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
