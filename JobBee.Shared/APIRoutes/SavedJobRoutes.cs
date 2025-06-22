using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class SavedJobRoutes
	{
		public const string Index = "api/savedJobs";

		public static class ACTION
		{
			public const string GetListSavedJob = "list";
			public const string GetSavedJobDetail = "{id}";
			public const string CreateSavedJob = "create";
			public const string UpdateSavedJob = "update";
			public const string DeleteSavedJob = "delete";
			public const string GetSavedJobByCandidateId = "by-candidate-id";
		}
	}
}
