using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Industry.Commands.CreateIndustry
{
	public class CreateIndustryValidator : AbstractValidator<CreateIndustryCommand>
	{
		private readonly IIndustryRepository _industryRepository;

		public CreateIndustryValidator(IIndustryRepository industryRepository)
		{
			_industryRepository = industryRepository;
		}
	}
}
