using System.Reflection;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using FluentValidation;
using JobBee.Application.CloudService;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.EmailService;
using JobBee.Application.Features.Employer.Commands.CreateEmployer;
using JobBee.Application.Validators;
using JobBee.Domain.Config;
using JobBee.Shared.Shared;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using JobBee.Application.Models.PayOS;
using JobBee.Application.PayOSService;
using Net.payOS;

namespace JobBee.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.Configure<ElasticSearchSettings>(configuration.GetSection("ElasticSearchSettings"));
			services.Configure<S3Settings>(configuration.GetSection("S3Settings"));
			services.AddSingleton<IAmazonS3>(options =>
			{
				var s3Settings = options.GetRequiredService<IOptions<S3Settings>>().Value;
				var config = new AmazonS3Config
				{
					RegionEndpoint = RegionEndpoint.GetBySystemName(s3Settings.Region),
				};
				return new AmazonS3Client(config);
			});
			services.Configure<PayOSSettings>(configuration.GetSection("PayOSSettings"));
			services.Configure<ReturnSettings>(configuration.GetSection("PayOSUrl"));
			services.AddScoped<PayOS>(options =>
			{
				var payOSSettings = options.GetRequiredService<IOptions<PayOSSettings>>().Value;
				var returnSettings = options.GetRequiredService<IOptions<ReturnSettings>>().Value;
				return new PayOS(payOSSettings.ClientID, payOSSettings.APIKey, payOSSettings.CheckSumKey);
			});
			services.AddScoped<WebhookInitializer>();

			services.AddSingleton(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));
			services.AddScoped<IEmailService, EmailService.EmailService>();
			services.AddScoped<ICloudService, AWSService>();
			services.AddScoped<IPayOSService, Application.PayOSService.PayOSService>();

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			services.AddValidatorsFromAssemblyContaining<CreateEmployerCommandValidator>();
			services.AddScoped<IEmailService, EmailService.EmailService>();
			return services;
		}
	}
}
