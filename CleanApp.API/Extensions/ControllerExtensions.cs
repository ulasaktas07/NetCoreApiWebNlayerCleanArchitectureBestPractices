using CleanApp.API.Filters;

namespace CleanApp.API.Extensions
{
	public static class ControllerExtensions
	{
		public static IServiceCollection AddControllersWithFiltersExt(this IServiceCollection services)
		{
			services.AddScoped(typeof(NotFoundFilter<,>));


			// Add custom filters here
			services.AddControllers(options =>
			{
				options.Filters.Add<FluentValidationFilter>();
				options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; // Suppress implicit required attribute for non-nullable reference types
			});
			return services;
		}

	}
}
