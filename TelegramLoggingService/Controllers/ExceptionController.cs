using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.DAL.Models;
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
			Guid id = new Guid(HttpContext.GetRouteData().Values["id"].ToString());

			_exceptionService.HandleException(id, Mapper.Map<IExceptionInfo>(model));

			return Ok();
		}
	}
}
