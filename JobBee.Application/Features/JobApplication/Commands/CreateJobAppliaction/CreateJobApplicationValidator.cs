using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobApplication.Commands.CreateJobAppliaction
{
	public class CreateJobApplicationValidator : AbstractValidator<CreateJobApplicationCommand>
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;

		public CreateJobApplicationValidator(IJobApplicationRepository jobApplicationRepository)
		{
			_jobApplicationRepository = jobApplicationRepository;
		}
	}
}
