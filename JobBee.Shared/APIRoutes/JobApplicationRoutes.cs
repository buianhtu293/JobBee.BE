using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class JobApplicationRoutes
	{
		public const string Index = "api/jobApplications";

		public static class ACTION
		{
			public const string GetListSkill = "list";
			public const string GetJobApplicationDetail = "{id}";
			public const string CreateJobApplication = "create";
			public const string UpdateJobApplication = "update";
			public const string DeleteJobApplication = "delete/{id}";
			public const string GetJobApplicationByCandidateId = "by-candidate-id";
		}
	}
}
