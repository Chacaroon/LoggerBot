using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Abstraction;

namespace BLL.MessageTemplates
{
	class SendSubscribeTokenMessageTemplate : IMessageTemplate
	{
		public string Text { get; set; }
		public ParseMode ParseMode { get; set; }
		public IReplyMarkup ReplyMarkup { get; set; }

		public SendSubscribeTokenMessageTemplate()
		{
			Text = new StringBuilder()
				.AppendLine("Чтобы подписать тебя на рассылку логгера, мне нужен его *Subscribe Token*.")
				.AppendLine("Токен может получить владелец логгера в настройках.")
				.AppendLine("Отправь мне *Subscribe Token*")
				.ToString();

			ParseMode = ParseMode.Markdown;
		}
	}
}
