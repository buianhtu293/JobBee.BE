using System.Reflection;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.EmailService;
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
			services.Configure<ElasticSearchSettings>(configuration.GetSection("ElasticSearchSettings"));
			services.AddSingleton(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));
			services.AddScoped<IEmailService, EmailService.EmailService>();
			return services;
		}
	}
}
