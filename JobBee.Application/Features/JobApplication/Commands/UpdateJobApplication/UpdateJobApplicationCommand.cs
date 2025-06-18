using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Commands.UpdateJobApplication
{
	public class UpdateJobApplicationCommand : IRequest<ApiResponse<UpdateJobApplicationDto>>
	{
		public Guid Id { get; set; }
		public string Status { get; set; } = null!;
	}
}
