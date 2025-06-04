namespace CleanApp.API.Extensions
{
	public static class ConfigurePipelineExtensions
	{
		public static IApplicationBuilder UseCustomPipelineeExt(this WebApplication app)
		{
			app.UseExceptionHandler(x => { });

			if (app.Environment.IsDevelopment())
			{
				app.UseSwaggerExt(); // Custom extension method to use Swagger
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			return app;
		}
	}
}
