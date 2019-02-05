using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.Markups
{
	public class MenuMarkup : InlineKeyboardMarkup
	{
		public MenuMarkup()
		{
			AddRow(
				new InlineKeyboardButton("My loggers", callbackData: "loggers"),
				new InlineKeyboardButton("AddLogger", callbackData: "addLogger"));
		}
	}
}
