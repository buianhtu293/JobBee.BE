using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobType.Commands.CreateJobType
{
	public class CreateJobTypeCommand : IRequest<ApiResponse<CreateJobTypeDto>>
	{
		public string TypeName { get; set; } = null!;
	}
}
