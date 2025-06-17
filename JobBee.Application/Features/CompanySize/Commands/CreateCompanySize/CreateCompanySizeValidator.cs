using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.CompanySize.Commands.CreateCompanySize
{
	public class CreateCompanySizeValidator : AbstractValidator<CreateCompanySizeCommand>
	{
		private readonly ICompanySizeRepository _companySizeRepository;

		public CreateCompanySizeValidator(ICompanySizeRepository companySizeRepository)
		{
			_companySizeRepository = companySizeRepository;
		}
	}
}
