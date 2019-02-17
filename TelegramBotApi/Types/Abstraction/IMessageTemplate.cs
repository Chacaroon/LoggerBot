using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApi.Types.Abstraction
{
	public interface IMessageTemplate
	{
		string Text { get; set; }
		ParseMode ParseMode { get; set; }
		IReplyMarkup ReplyMarkup { get; set; }
	}
}
