using JobBee.Application.Contracts.Email;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Models.Email;
using JobBee.Application.Services.ElasticSearchService;
using JobBee.Domain.Config;
using JobBee.Infrastructure.EmailService;
using JobBee.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobBee.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			services.Configure<ElasticSearchSettings>(configuration.GetSection("ElasticSearchSettings"));
			services.AddSingleton(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));
			return services;
		}
	}
}
