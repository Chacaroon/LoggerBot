using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class AddLoggerSuccessMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public AddLoggerSuccessMessageTemplate(Guid publicToken)
		{
			Text = new StringBuilder()
				.AppendLine("Логгер успешно добавлен.")
				.AppendLine("Вот твой токен")
				.AppendLine($"`{publicToken}`")
				.ToString();

			ParseMode = ParseMode.Markdown;

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(new InlineKeyboardButton("В меню", callbackData: "menu"));
		}
	}
}
