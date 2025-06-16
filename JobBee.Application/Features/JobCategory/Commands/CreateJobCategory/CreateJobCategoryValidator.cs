using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobCategory.Commands.CreateJobCategory
{
	public class CreateJobCategoryValidator : AbstractValidator<CreateJobCategoryCommand>
	{
		private readonly IJobCategoryRepository _jobCategoryRepository;

		public CreateJobCategoryValidator(IJobCategoryRepository jobCategoryRepository)
		{
			_jobCategoryRepository = jobCategoryRepository;
		}
	}
}
