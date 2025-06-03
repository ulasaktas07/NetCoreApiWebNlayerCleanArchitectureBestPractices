using App.Aplication.Features.Categories;
using App.Aplication.Features.Products;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Aplication.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true); // Disable automatic model state validation


			services.AddScoped<IProductSevice, ProductService>();
			services.AddScoped<ICategoryService, CategoryService>();


			services.AddFluentValidationAutoValidation();

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			
			return services;
		}
	}
}
