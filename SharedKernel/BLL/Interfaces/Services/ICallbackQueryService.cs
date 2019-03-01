using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types.ReplyMarkup;

namespace SharedKernel.BLL.Interfaces.Services
{
	public interface ICallbackQueryService
	{
		Task HandleRequest(CallbackQuery callbackQuery);
	}
}
