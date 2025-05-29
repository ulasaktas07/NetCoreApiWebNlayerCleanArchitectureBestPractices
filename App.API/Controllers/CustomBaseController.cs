﻿using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomBaseController : ControllerBase
	{
		[NonAction]
		public IActionResult CreateActionResult<T>(ServiceResult<T> result)
		{
			return result.Status switch
			{
				HttpStatusCode.NoContent => NoContent(),
				HttpStatusCode.Created => Created(result.UrlAsCreated, result.Data),
				_ => new ObjectResult(result) { StatusCode = result.Status.GetHashCode() }
			};
		}
		[NonAction]
		public IActionResult CreateActionResult(ServiceResult result)
		{
			return result.Status switch
			{
				HttpStatusCode.NoContent => NoContent(),
				_ => new ObjectResult(result) { StatusCode = result.Status.GetHashCode() }
			};
		}
	}
}
