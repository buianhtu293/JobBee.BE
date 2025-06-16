using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Commands.CreateExperienceLevel
{
	public class CreateExperienceLevelCommand : IRequest<ApiResponse<CreateExperienceLevelDto>>
	{
		public string LevelName { get; set; } = null!;
	}
}
