using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CompanySize.Queries.GetAllCompanySize
{
	public class CompanySizeDto
	{
		public Guid Id { get; set; }
		public string SizeRange { get; set; } = null!;
	}
}
