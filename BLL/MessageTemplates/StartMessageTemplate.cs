using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class StartMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public StartMessageTemplate()
		{
			Text = new StringBuilder()
				.AppendLine("Приветствую тебя, разработчик. Меня зовут *Loggario*.")
				.Append("Я могу следить за твоими приложениями и сообщать тебе об ошибках, ")
				.AppendLine("которые они выбрасывают")
				.AppendLine("Давай приступим к созданию твоего личного логгера!")
				.AppendLine()
				.AppendLine("Чтобы начать работу, перейди в /menu")
				.ToString();

			ParseMode = ParseMode.Markdown;
		}
	}
}
