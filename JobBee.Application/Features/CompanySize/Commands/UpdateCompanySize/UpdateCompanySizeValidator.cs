using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.CompanySize.Commands.UpdateCompanySize
{
	public class UpdateCompanySizeValidator : AbstractValidator<UpdateCompanySizeCommand>
	{
		private readonly ICompanySizeRepository _companySizeRepository;

		public UpdateCompanySizeValidator(ICompanySizeRepository companySizeRepository)
		{
			_companySizeRepository = companySizeRepository;
		}
	}
}
