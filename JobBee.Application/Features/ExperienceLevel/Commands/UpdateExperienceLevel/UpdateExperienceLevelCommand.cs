using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Commands.UpdateExperienceLevel
{
	public class UpdateExperienceLevelCommand : IRequest<ApiResponse<UpdateExperienceLevelDto>>
	{
		public Guid Id { get; set; }
		public string LevelName { get; set; } = null!;
	}
}
