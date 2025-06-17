using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CompanySize.Queries.GetCompanySizeDetail
{
	public class CompanySizeDetailDto
	{
		public Guid Id { get; set; }
		public string SizeRange { get; set; } = null!;
	}
}
