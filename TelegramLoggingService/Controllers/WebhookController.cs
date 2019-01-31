using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.PL.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramLoggingService.Controllers
{
	[Route("api/[controller]")]
	public class WebhookController : Controller
	{
		// POST: api/<controller>
		[HttpPost]
		public IActionResult Post([FromBody]UpdateViewModel model)
		{
			return Ok();
		}
	}
}
