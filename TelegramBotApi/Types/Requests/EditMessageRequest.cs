using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.Abstraction;

namespace TelegramBotApi.Types.Requests
{
	class EditMessageRequest : BaseRequest
	{
		public long ChatId { get; set; }
		public long MessageId { get; set; }

		public string Text { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ParseMode { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool DisableWebPagePreview { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public IReplyMarkup ReplyMarkup { get; set; }

		public EditMessageRequest(long chatId, long messageId, string text)
		{
			ChatId = chatId;
			MessageId = messageId;
			Text = text;
		}

		public EditMessageRequest(
			long chatId,
			long messageId,
			string text,
			ParseMode parseMode,
			bool disableWebPagePreview,
			IReplyMarkup replyMarkup)
			: this(chatId, messageId, text)
		{
			ParseMode = parseMode.ToString();
			DisableWebPagePreview = disableWebPagePreview;
			ReplyMarkup = replyMarkup;
		}
	}
}
