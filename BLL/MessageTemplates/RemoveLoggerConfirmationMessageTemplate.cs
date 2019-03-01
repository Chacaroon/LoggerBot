using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.MessageTemplates
{
	class RemoveLoggerConfirmationMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public RemoveLoggerConfirmationMessageTemplate(string loggerId)
		{
			Text = "Вы действительно хотите удалить логгер?";
			
			ReplyMarkup = new InlineKeyboardMarkup()
				.AddRow(
					new InlineKeyboardButton("Да", callbackData: $"removeLogger:answer=true,id={loggerId}"))
				.AddRow(
					new InlineKeyboardButton("Нет", callbackData: $"removeLogger:answer=false,id={loggerId}"));
		}
	}
}
