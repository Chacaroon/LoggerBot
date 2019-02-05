using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace SharedKernel.BLL.Interfaces.MessageTemplates
{
	public interface IMessageTemplate
	{
		string Text { get; set; }
		ParseMode ParseMode { get; set; }
		IReplyMarkup ReplyMarkup { get; set; }
	}
}
