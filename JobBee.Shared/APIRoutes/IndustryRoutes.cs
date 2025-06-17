using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class IndustryRoutes
	{
		public const string Index = "api/industries";

		public static class ACTION
		{
			public const string GetListIndustry = "list";
			public const string GetIndustryDetail = "{id}";
			public const string CreateIndustry = "create";
			public const string UpdateIndustry = "update";
			public const string DeleteIndustry = "delete/{id}";
		}
	}
}
