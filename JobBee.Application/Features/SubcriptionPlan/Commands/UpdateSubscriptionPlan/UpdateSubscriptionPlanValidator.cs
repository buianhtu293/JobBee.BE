using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.SubcriptionPlan.Commands.UpdateSubscriptionPlan
{
	public class UpdateSubscriptionPlanValidator : AbstractValidator<UpdateSubscriptionPlanCommand>
	{
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;

		public UpdateSubscriptionPlanValidator(ISubcriptionPlanRepository subcriptionPlanRepository)
		{
			_subcriptionPlanRepository = subcriptionPlanRepository;
		}
	}
}
