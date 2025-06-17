using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Industry.Queries.GetAllIndustry
{
	public class IndustryDto
	{
		public Guid Id { get; set; }
		public string IndustryName { get; set; } = null!;
	}
}
