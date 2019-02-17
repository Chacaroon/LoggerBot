using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class LoggerInfoMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public LoggerInfoMessageTemplate(string name, int exceptionsCount, long loggerId)
		{
			Text = new StringBuilder()
				.AppendLine($"*Имя:* {name}")
				.AppendLine($"*Ошибок:* {exceptionsCount}")
				.AppendLine()
				.ToString();

			ParseMode = ParseMode.Markdown;

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(
				new InlineKeyboardButton("Private Token", callbackData: $"showPrivateToken:id={loggerId}"),
				new InlineKeyboardButton("Subscribe Token", callbackData: $"showSubscribeToken:id={loggerId}"))
				.AddRow(
					new InlineKeyboardButton("В меню", callbackData: "menu"));
		}
	}
}
