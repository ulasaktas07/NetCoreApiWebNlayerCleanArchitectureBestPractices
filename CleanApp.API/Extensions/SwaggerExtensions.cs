namespace CleanApp.API.Extensions
{
	public static class SwaggerExtensions
	{
		public static IServiceCollection AddSwaggerExt(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "CleanApp API",
					Version = "v1",
					Description = "API for CleanApp application"
				});
				c.CustomSchemaIds(type => type.FullName); // Use full name for schema IDs to avoid conflicts
			});
			return services;
		}
		public static IApplicationBuilder UseSwaggerExt(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI();
			return app;
		}
	}
}
