using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class UndefinedCommandMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public UndefinedCommandMessageTemplate()
		{
			Text = "Что ты несёшь? Я тебя не понимаю...";
		}
	}
}
