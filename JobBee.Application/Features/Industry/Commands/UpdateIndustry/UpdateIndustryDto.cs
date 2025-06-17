using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Industry.Commands.UpdateIndustry
{
	public class UpdateIndustryDto
	{
		public Guid Id { get; set; }
		public string IndustryName { get; set; } = null!;
	}
}
