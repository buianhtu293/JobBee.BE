using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class CandidateResumeRoutes
	{
		public const string Index = "api/candidateResumes";

		public static class ACTION
		{
			public const string GetListCandidateResume = "list";
			public const string GetCandidateResumeDetail = "{id}";
			public const string CreateCandidateResume = "create";
			public const string UpdateCandidateResume = "update";
			public const string DeleteCandidateResume = "delete/{id}";
			public const string GetCandidateResumeByCandidateId = "by-candidate-id/{id}";
		}
	}
}
