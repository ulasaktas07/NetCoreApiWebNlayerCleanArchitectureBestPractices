using App.Repositories.Extensions;
using App.Services;
using App.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace App.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers(options=> {
				options.Filters.Add<FluentValidationFilter>();
				options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; // Suppress implicit required attribute for non-nullable reference types
			});
			builder.Services.Configure<ApiBehaviorOptions>(options =>options.SuppressModelStateInvalidFilter = true); // Disable automatic model state validation
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
