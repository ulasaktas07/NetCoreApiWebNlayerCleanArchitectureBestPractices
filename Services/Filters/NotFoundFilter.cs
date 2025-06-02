using App.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Services.Filters
{
	public class NotFoundFilter<T, TId>(IGenericRepository<T, TId> genericRepository) : Attribute, IAsyncActionFilter where T : class where TId : struct
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.ActionArguments.TryGetValue("id", out var idValue) || idValue is not TId id)
			{
				await next();
				return;
			}

			if (await genericRepository.AnyAsync(id))
			{
				await next();
				return;

			}

			var entityName = typeof(T).Name;
			var actionName = context.ActionDescriptor.RouteValues["action"];

			var result = ServiceResult.Fail($"data bulunamamıştır. ({entityName})({actionName})");
			context.Result = new NotFoundObjectResult(result);
		}
	}
}
