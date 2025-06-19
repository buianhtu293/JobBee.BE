using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobAlert.Commands.CreateJobAlert
{
	public class CreateJobAlertCommand : IRequest<ApiResponse<CreateJobAlertDto>>
	{
		public Guid JobId { get; set; }
		public string AlertName { get; set; } = null!;
	}
}
