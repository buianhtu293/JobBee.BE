using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Industry.Commands.UpdateIndustry
{
	public class UpdateIndustryValidator : AbstractValidator<UpdateIndustryCommand>
	{
		private readonly IIndustryRepository _industryRepository;

		public UpdateIndustryValidator(IIndustryRepository industryRepository)
		{
			_industryRepository = industryRepository;
		}
	}
}
