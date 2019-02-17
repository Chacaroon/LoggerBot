using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class SubscribeInfoMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public SubscribeInfoMessageTemplate(string name, int exceptionsCount)
		{
			Text = new StringBuilder()
				.AppendLine($"*Имя:* {name}")
				.AppendLine($"*Ошибок:* {exceptionsCount}")
				.ToString();

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(new InlineKeyboardButton("В меню", callbackData: "menu"));

			ParseMode = ParseMode.Markdown;
		}
	}
}
