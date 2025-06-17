using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CompanySize.Commands.UpdateCompanySize
{
	public class UpdateCompanySizeDto
	{
		public Guid Id { get; set; }
		public string SizeRange { get; set; } = null!;
	}
}
