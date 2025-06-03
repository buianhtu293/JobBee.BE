using JobBee.Api.Middleware;
using JobBee.Api.OptionsSetup;
using JobBee.Application;
using JobBee.Infrastructure;
using JobBee.Persistence;
using JobBee.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddApplicationServices(builder.Configuration);
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddPersistenceServices(builder.Configuration);

			builder.Services.AddControllers();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("all", builder => builder.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod());
			});

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//Jwt
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer();

			builder.Services.ConfigureOptions<JwtOptionsSetup>();
			builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

			var app = builder.Build();

			//using (var scope = app.Services.CreateScope())
			//{
			//	var dbContext = scope.ServiceProvider.GetRequiredService<JobBeeContext>();
			//	dbContext.Database.Migrate(); // Applies any pending EF Core migrations
			//}

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
