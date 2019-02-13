using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class ShowSubscribeTokenMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public ShowSubscribeTokenMessageTemplate(Guid token)
		{
			Text = new StringBuilder()
				.AppendLine("Этот токен позволит подписаться на рассылку твоего логгера")
				.AppendLine()
				.AppendLine($"`{token}`")
				.ToString();

			ParseMode = ParseMode.Markdown;
		}
	}
}
