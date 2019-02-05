using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.BLL.Interfaces.Services;
using TelegramBotApi.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramLoggingService.Controllers
{
	[Route("api/[controller]")]
	public class WebhookController : Controller
	{
		private IMessageService _messageService;
		private ICallbackQueryService _callbackQueryService;

		public WebhookController(
			IMessageService messageService,
			ICallbackQueryService callbackQueryService)
		{
			_messageService = messageService;
			_callbackQueryService = callbackQueryService;
		}

		// POST: api/<controller>
		[HttpPost]
		public IActionResult Post([FromBody]Update update)
		{
			if (update.IsMessage())
				_messageService.HandleRequest(update.Message);

			if (update.IsCallbackQuery())
				_callbackQueryService.HandleRequest(update.CallbackQuery);

			return Ok();
		}
	}
}
