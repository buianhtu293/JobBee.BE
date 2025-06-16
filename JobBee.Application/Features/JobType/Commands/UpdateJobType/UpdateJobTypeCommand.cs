using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobType.Commands.UpdateJobType
{
	public class UpdateJobTypeCommand : IRequest<ApiResponse<UpdateJobTypeDto>>
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
	}
}
