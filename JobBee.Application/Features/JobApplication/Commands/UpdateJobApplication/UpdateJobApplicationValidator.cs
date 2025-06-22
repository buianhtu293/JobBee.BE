using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobApplication.Commands.UpdateJobApplication
{
	public class UpdateJobApplicationValidator : AbstractValidator<UpdateJobApplicationCommand>
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;

		public UpdateJobApplicationValidator(IJobApplicationRepository jobApplicationRepository)
		{
			_jobApplicationRepository = jobApplicationRepository;
		}
	}
}
