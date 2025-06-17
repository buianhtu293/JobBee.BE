using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class CompanySizeRoutes
	{
		public const string Index = "api/companySizes";

		public static class ACTION
		{
			public const string GetListCompanySize = "list";
			public const string GetCompanySizeDetail = "{id}";
			public const string CreateCompanySize = "create";
			public const string UpdateCompanySize = "update";
			public const string DeleteCompanySize = "delete/{id}";
		}
	}
}
