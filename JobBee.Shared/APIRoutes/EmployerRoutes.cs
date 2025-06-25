namespace JobBee.Shared.APIRoutes
{
	public class EmployerRoutes
	{
		public const string Index = $"{CommonRoutes.API}/employers";

		public static class ACTION
		{
			public const string GetList = "";
			public const string GetDetail = "{id}";
			public const string Create = "";
			public const string Update = "{id}";
			public const string Delete = "{id}";
			public const string GetListPageResult = "page-result";
			public const string GetTopEmployer = "top";
		}
	}
}
