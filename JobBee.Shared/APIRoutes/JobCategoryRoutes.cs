using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class JobCategoryRoutes
	{
		public const string Index = "api/jobCategory";

		public static class ACTION
		{
			public const string GetListJobCategory = "list";
			public const string GetJobCategoryDetail = "{id}";
			public const string CreateJobCategory = "create";
			public const string UpdateJobCategory = "update";
			public const string DeleteJobCategory = "delete/{id}";
			public const string GetPopularCategory = "popular";
		}
	}
}
