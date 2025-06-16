using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class SkillRoutes
	{
		public const string Index = "api/skills";

		public static class ACTION
		{
			public const string GetListSkill = "list";
			public const string GetSkillDetail = "{id}";
			public const string CreateSkill = "create";
			public const string UpdateSkill = "update";
			public const string DeleteSkill = "delete/{id}";
		}
	}
}
