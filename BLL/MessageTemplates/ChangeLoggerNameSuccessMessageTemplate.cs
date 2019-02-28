using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class ChangeLoggerNameSuccessMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public ChangeLoggerNameSuccessMessageTemplate()
		{
			Text = "Имя логгера успешно изменено";

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(
					new InlineKeyboardButton("В меню", callbackData: "menu"));
		}
	}
}
