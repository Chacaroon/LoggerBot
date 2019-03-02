using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class RemoveLoggerSuccessMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public RemoveLoggerSuccessMessageTemplate()
		{
			Text = "Логгер успешно удалён";

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(
					new InlineKeyboardButton("В меню", callbackData: "menu"));
		}
	}
}
