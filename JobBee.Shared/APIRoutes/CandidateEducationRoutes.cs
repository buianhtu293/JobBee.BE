using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class CandidateEducationRoutes
	{
		public const string Index = "api/candidateEducations";

		public static class ACTION
		{
			public const string GetListCandidateEducation = "list";
			public const string GetCandidateEducationDetail = "{id}";
			public const string CreateCandidateEducation = "create";
			public const string UpdateCandidateEducation = "update";
			public const string DeleteCandidateEducation = "delete/{id}";
			public const string GetCandidateEducationByCandidateId = "by-candidate/{id}";
		}
	}
}
