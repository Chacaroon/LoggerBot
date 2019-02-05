using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.ReplyMarkup;

namespace SharedKernel.BLL.Interfaces.Services
{
	public interface ICallbackQueryService
	{
		void HandleRequest(CallbackQuery callbackQuery);
	}
}
