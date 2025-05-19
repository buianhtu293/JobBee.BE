using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Api.Extentions
{
	public static class MigrationExtensions
	{
		public static void ApplyExtensions(this IApplicationBuilder app)
		{
			using IServiceScope scope = app.ApplicationServices.CreateScope();

			using JobBeeDatabaseContext dbContext = scope.ServiceProvider.GetRequiredService<JobBeeDatabaseContext>();

			dbContext.Database.Migrate();
		}
	}
}
