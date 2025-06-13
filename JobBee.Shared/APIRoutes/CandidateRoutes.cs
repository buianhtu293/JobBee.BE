using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class CandidateRoutes
	{
		public const string Index = "api/candidate";

		public static class ACTION
		{
			public const string GetListCandidate = "list";
			public const string GetCandidateDetail = "{id}";
			public const string CreateCandidate = "create";
			public const string UpdateCandidate = "update";
			public const string DeleteCandidate = "delete/{id}";
		}
	}
}
