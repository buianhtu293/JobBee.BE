using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class JobTypeRoutes
	{
		public const string Index = "api/jobTypes";

		public static class ACTION
		{
			public const string GetListJobType = "list";
			public const string GetJobTypeDetail = "{id}";
			public const string CreateJobType = "create";
			public const string UpdateJobType = "update";
			public const string DeleteJobType = "delete/{id}";
		}
	}
}
