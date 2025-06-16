using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobType.Commands.UpdateJobType
{
	public class UpdateJobTypeValidator : AbstractValidator<UpdateJobTypeCommand>
	{
		private readonly IJobTypeRepository _jobTypeRepository;

		public UpdateJobTypeValidator(IJobTypeRepository jobTypeRepository)
		{
			_jobTypeRepository = jobTypeRepository;
		}
	}
}
