using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Industry.Commands.CreateIndustry
{
	public class CreateIndustryDto
	{
		public Guid Id { get; set; }
		public string IndustryName { get; set; } = null!;
	}
}
