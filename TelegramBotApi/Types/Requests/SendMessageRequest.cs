using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.Abstraction;

namespace TelegramBotApi.Types.Requests
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	class SendMessageRequest : BaseRequest
	{
		public long ChatId { get; set; }

		public string Text { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ParseMode { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool DisableWebPagePreview { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool DisableNotification { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public long ReplyToMessageId { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public IReplyMarkup ReplyMarkup { get; set; }

		public SendMessageRequest(long chatId, string text)
		{
			ChatId = chatId;
			Text = text;
		}

		public SendMessageRequest(
			long chatId,
			string text,
			string parseMode,
			bool disableWebPagePreview,
			bool disableNotification,
			long replyToMessageId,
			IReplyMarkup replyMarkup)
			: this(chatId, text)
		{
			ParseMode = parseMode;
			DisableWebPagePreview = disableWebPagePreview;
			DisableNotification = disableNotification;
			ReplyToMessageId = replyToMessageId;
			ReplyMarkup = replyMarkup;
		}
	}
}
