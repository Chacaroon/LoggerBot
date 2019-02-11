using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class ExceptionInfoMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public ExceptionInfoMessageTemplate(string loggerName, string message, string stackTrace)
		{
			Text = new StringBuilder()
				.AppendLine($"*Логгер:* {loggerName}")
				.AppendLine()
				.AppendLine($"```{message}")
				.AppendLine($"{stackTrace}```")
				.ToString();

			ParseMode = ParseMode.Markdown;
		}
	}
}
