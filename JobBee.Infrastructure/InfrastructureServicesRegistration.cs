using JobBee.Application.Contracts.Email;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Models.Email;
using JobBee.Infrastructure.EmailService;
using JobBee.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobBee.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

			return services;
		}
	}
}
