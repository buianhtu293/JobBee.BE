using Amazon.Extensions.NETCore.Setup;
using JobBee.Api.Middleware;
using JobBee.Api.OptionsSetup;
using JobBee.Application;
using JobBee.Infrastructure;
using JobBee.Infrastructure.Authentication;
using JobBee.Persistence;
using JobBee.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JobBee.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowFrontend", policy =>
				{
					policy.WithOrigins("http://localhost:4200", "https://jobbeefe.vercel.app") 
						  .AllowAnyHeader()                    
						  .AllowAnyMethod()
						  .AllowCredentials();
				});
			});

			// Add services to the container.

			builder.Services.AddApplicationServices(builder.Configuration);
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddPersistenceServices(builder.Configuration);

			builder.Services.AddControllers();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "File Upload API",
					Version = "v1"
				});

				c.MapType<IFormFile>(() => new OpenApiSchema
				{
					Type = "string",
					Format = "binary"
				});

				c.MapType<IFormFileCollection>(() => new OpenApiSchema
				{
					Type = "array",
					Items = new OpenApiSchema
					{
						Type = "string",
						Format = "binary"
					}
				});
			});

			//Jwt
			builder.Services.ConfigureOptions<JwtOptionsSetup>();
			builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
			var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!);
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
					{
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidIssuer = builder.Configuration["Jwt:Issuer"],

							ValidateAudience = true,
							ValidAudience = builder.Configuration["Jwt:Audience"],

							ValidateLifetime = true,
							ClockSkew = TimeSpan.Zero,

							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(key),

							NameClaimType = "sub"
						};
					});

			builder.WebHost.ConfigureKestrel(options =>
			{

				var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

				if (env == Environments.Development)
				{
					options.ListenAnyIP(5000);
					options.ListenAnyIP(5001);
				}
				else if (env == Environments.Production)
				{
					options.ListenAnyIP(5000);
					options.ListenAnyIP(5001, listenOptions =>
					{
						listenOptions.UseHttps("/https/cert.pfx", "Callmebean03@");
					});
				}
			});

			var app = builder.Build();

			app.UseCors("AllowFrontend");

			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<JobBeeContext>();
				dbContext.Database.Migrate(); // Applies any pending EF Core migrations
			}

			app.UseCors(x => x
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());

			app.UseMiddleware<ExceptionMiddleware>();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();
			app.Run();
		}
	}
}
