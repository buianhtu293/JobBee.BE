using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobType.Commands.CreateJobType
{
	public class CreateJobTypeValidator : AbstractValidator<CreateJobTypeCommand>
	{
		private readonly IJobTypeRepository _jobTypeRepository;

		public CreateJobTypeValidator(IJobTypeRepository jobTypeRepository)
		{
			_jobTypeRepository = jobTypeRepository;
		}
	}
}
