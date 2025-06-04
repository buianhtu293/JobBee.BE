using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;
using JobBee.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobBee.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			#region Config SQL Server
			//services.AddDbContext<JobBeeDatabaseContext>(options =>
			//{
			//	options.UseSqlServer(configuration.GetConnectionString("JobBeeDatabaseConnectionString"));
			//});
			#endregion

			#region Config PostgreSQL
			services.AddDbContext<JobBeeContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("JobBeeDatabaseConnectionString"));	
			});
			#endregion

			services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
			services.AddScoped(typeof(IUnitOfWork<,>), typeof(UnitOfWork<,>));

			services.AddScoped<ISkillCategoryRepository, SkillCategoryRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();

			return services;
		}
	}
}
