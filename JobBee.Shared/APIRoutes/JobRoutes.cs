namespace JobBee.Shared.APIRoutes
{
	public class JobRoutes
	{
		public const string Index = $"{CommonRoutes.API}/jobs";

		public static class ACTION
		{
			public const string Search = "search";
			public const string GetDetail = "{id}";
			public const string Create = "";
			public const string Edit = "";
			public const string Delete = "{id}";
			public const string GetPostedJob = "posted-job";
		}
	}
}
