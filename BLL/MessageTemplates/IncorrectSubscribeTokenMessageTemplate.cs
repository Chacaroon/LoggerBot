using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class IncorrectSubscribeTokenMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public IncorrectSubscribeTokenMessageTemplate()
		{
			Text = new StringBuilder()
				.AppendLine("Некорректный *Subscribe Token*!")
				.AppendLine("Повтори попытку или напиши /cancel, чтобы отменить операцию")
				.ToString();

			ParseMode = ParseMode.Markdown;
		}
	}
}
