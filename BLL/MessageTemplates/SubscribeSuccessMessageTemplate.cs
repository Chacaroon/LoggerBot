using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class SubscribeSuccessMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public SubscribeSuccessMessageTemplate(string loggerName)
		{
			Text = new StringBuilder()
				.AppendLine($"Ты подписался на рассылку логгера _{loggerName}_")
				.ToString();

			ParseMode = ParseMode.Markdown;

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(new InlineKeyboardButton("В меню", callbackData: "menu"));
		}
	}
}
