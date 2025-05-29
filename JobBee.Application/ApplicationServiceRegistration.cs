using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JobBee.Application.Services;
using JobBee.Domain.Config;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobBee.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddSingleton(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));
			services.Configure<ElasticSearchSettings>(configuration.GetSection("ElasticSearchSettings"));

			return services;
		}
	}
}
