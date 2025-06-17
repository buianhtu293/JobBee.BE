using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CompanySize.Commands.CreateCompanySize
{
	public class CreateCompanySizeDto
	{
		public Guid Id { get; set; }
		public string SizeRange { get; set; } = null!;
	}
}
