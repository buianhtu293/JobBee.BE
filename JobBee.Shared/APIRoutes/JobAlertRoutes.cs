using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class JobAlertRoutes
	{
		public const string Index = "api/jobAlerts";

		public static class ACTION
		{
			public const string GetListJobAlert = "list";
			public const string GetJobAlertDetail = "{id}";
			public const string CreateJobAlert = "create";
			public const string UpdateJobAlert = "update";
			public const string DeleteJobAlert = "delete";
			public const string GetJobAlertByCandidateId = "by-candidate-id";
		}
	}
}
