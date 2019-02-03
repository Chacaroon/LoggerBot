using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.Markups
{
	public class StartMarkup : InlineKeyboardMarkup
	{
		public StartMarkup()
		{
			AddRow(new[]
			{
				new InlineKeyboardButton("My loggers", callbackData: "loggers"),
				new InlineKeyboardButton("AddLogger", callbackData: "addLogger")
			});
		}
	}
}
