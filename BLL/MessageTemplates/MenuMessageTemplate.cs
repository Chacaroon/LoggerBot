using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class MenuMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public MenuMessageTemplate()
		{
			Text = "Меню";

			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(
					new InlineKeyboardButton("Мои логгеры", callbackData: "loggers"),
					new InlineKeyboardButton("Добавить логгер", callbackData: "addLogger")
				)
				.AddRow(
					new InlineKeyboardButton("Подписки", callbackData: "subscribes"),
					new InlineKeyboardButton("Подписаться", callbackData: "subscribe")
				);
		}
	}
}
