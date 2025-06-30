using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class SubscriptionPlanRoutes
	{
		public const string Index = "api/supscriptionPlans";

		public static class ACTION
		{
			public const string GetListSubscriptionPlan = "list";
			public const string GetSubscriptionPlanDetail = "{id}";
			public const string CreateSubscriptionPlan = "create";
			public const string UpdateSubscriptionPlan = "update";
			public const string DeleteSubscriptionPlan = "delete/{id}";
		}
	}
}
