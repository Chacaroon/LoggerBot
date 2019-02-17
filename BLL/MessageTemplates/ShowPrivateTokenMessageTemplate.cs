using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class ShowPrivateTokenMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public ShowPrivateTokenMessageTemplate(Guid token)
		{
			Text = new StringBuilder()
				.AppendLine("Испльзуй этот токен для настройки логгера в своём приложении")
				.AppendLine()
				.AppendLine($"`{token}`")
				.ToString();

			ParseMode = ParseMode.Markdown;
		}
	}
}
