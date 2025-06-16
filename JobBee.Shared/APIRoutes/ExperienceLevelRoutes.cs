using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class ExperienceLevelRoutes
	{
		public const string Index = "api/experienceLevels";

		public static class ACTION
		{
			public const string GetListExperienceLevel = "list";
			public const string GetExperienceLevelDetail = "{id}";
			public const string CreateExperienceLevel = "create";
			public const string UpdateExperienceLevel = "update";
			public const string DeleteExperienceLevel = "delete/{id}";
		}
	}
}
