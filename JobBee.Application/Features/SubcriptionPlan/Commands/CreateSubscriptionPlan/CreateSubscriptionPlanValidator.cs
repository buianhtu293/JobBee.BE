using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.SubcriptionPlan.Commands.CreateSubscriptionPlan
{
	public class CreateSubscriptionPlanValidator : AbstractValidator<CreateSubscriptionPlanCommand>
	{
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;

		public CreateSubscriptionPlanValidator(ISubcriptionPlanRepository subcriptionPlanRepository)
		{
			_subcriptionPlanRepository = subcriptionPlanRepository;
		}
	}
}
