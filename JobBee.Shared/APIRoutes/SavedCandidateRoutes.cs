using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class SavedCandidateRoutes
	{
		public const string Index = "api/savedCandidates";

		public static class ACTION
		{
			public const string GetListSavedCandidate = "list";
			public const string GetSavedCandidateDetail = "{id}";
			public const string CreateSavedCandidate = "create";
			public const string UpdateSavedCandidate = "update";
			public const string DeleteSavedCandidate = "delete";
			public const string GetSavedCandidateByEmployer = "by-employer-id";
		}
	}
}
