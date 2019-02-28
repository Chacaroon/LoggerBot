using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class ChangeLoggerNameMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public ChangeLoggerNameMessageTemplate()
		{
			Text = new StringBuilder()
				.AppendLine("Укажите новое имя логгера")
				.ToString();
		}
	}
}
