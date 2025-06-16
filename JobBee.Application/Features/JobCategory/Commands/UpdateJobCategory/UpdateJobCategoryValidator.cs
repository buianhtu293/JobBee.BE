using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory
{
	public class UpdateJobCategoryValidator : AbstractValidator<UpdateJobCategoryCommand>
	{
		private readonly IJobCategoryRepository _jobCategoryRepository;

		public UpdateJobCategoryValidator(IJobCategoryRepository jobCategoryRepository)
		{
			_jobCategoryRepository = jobCategoryRepository;
		}
	}
}
