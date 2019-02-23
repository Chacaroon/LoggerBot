using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.DAL.Models;
using SharedKernel.Exceptons;
using TelegramLoggingService.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramLoggingService.Controllers
{
	[Route("api/[controller]")]
	public class ExceptionController : Controller
	{
		private IExceptionService _exceptionService;

		public ExceptionController(IExceptionService exceptionService)
		{
			_exceptionService = exceptionService;
		}

		// POST api/<controller>/5
		[HttpPost("{id}")]
		public IActionResult Post([FromBody]ExceptionViewModel model)
		{
			Guid id = Guid.Empty;

			if (!Guid.TryParse(HttpContext.GetRouteData().Values["id"].ToString(), out id))
			{
				return BadRequest("Token format is incorrect");
			}

			try
			{
				_exceptionService.HandleException(id, Mapper.Map<IExceptionInfo>(model));
			}
			catch (InvalidTokenException e)
			{
				return NotFound(e.Message);
			}
			catch
			{
				return BadRequest();
			}

			return Ok();
		}
	}
}
