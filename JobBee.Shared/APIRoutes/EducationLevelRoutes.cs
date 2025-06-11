using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class EducationLevelRoutes
	{
		public const string Index = "api/educationlevels";

		public static class ACTION
		{
			public const string GetListEducationLevel = "list";
			public const string GetEducationLevelDetail = "{id}";
			public const string CreateEducationLevel = "create";
			public const string UpdateEducationLevel = "update";
		}
	}
}
