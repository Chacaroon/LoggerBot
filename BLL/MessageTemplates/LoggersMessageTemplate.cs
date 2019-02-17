using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class LoggersMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public LoggersMessageTemplate(IReplyMarkup replyMarkup)
		{
			Text = new StringBuilder()
				.AppendLine("Это все твои логгеры")
				.ToString();

			replyMarkup.AddRow(
				new InlineKeyboardButton("В меню", callbackData: "menu"));

			ReplyMarkup = replyMarkup;
		}
	}
}
