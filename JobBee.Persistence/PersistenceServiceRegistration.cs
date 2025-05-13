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
			services.AddDbContext<JobBeeDatabaseContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("JobBeeDatabaseConnectionString"));
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
			services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
			services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

			return services;
		}
	}
}
