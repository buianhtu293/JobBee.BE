namespace JobBee.Shared.APIRoutes
{
	public class EmployerPhotoRoutes
	{
		public const string Index = $"{CommonRoutes.API}/company-photo";

		public static class ACTION
		{
			public const string GetList = "";
			public const string GetDetail = "{id}";
			public const string Create = "";
			public const string Update = "{id}";
			public const string Delete = "{id}";
		}
	}
}
