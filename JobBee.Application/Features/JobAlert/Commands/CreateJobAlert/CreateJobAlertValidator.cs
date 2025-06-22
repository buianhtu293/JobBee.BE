using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobAlert.Commands.CreateJobAlert
{
	public class CreateJobAlertValidator : AbstractValidator<CreateJobAlertCommand>
	{
		private readonly IJobAlertRepository _jobAlertRepository;

		public CreateJobAlertValidator(IJobAlertRepository jobAlertRepository)
		{
			_jobAlertRepository = jobAlertRepository;
		}
	}
}
