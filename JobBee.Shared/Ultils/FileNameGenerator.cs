namespace JobBee.Shared.Ultils
{
	public static class FileNameGenerator
	{
		public static string GenerateFileName()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
