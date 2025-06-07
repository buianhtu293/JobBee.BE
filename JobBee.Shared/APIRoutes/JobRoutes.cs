namespace JobBee.Shared.APIRoutes
{
	public class JobRoutes
	{
		public const string Index = "api/jobs";

		public static class ACTION
		{
			public const string GetListJobs = "";
			public const string GetDetail = "{id}";
			public const string Create = "";
			public const string Edit = "";
			public const string Delete = "{id}";
		}
	}
}
