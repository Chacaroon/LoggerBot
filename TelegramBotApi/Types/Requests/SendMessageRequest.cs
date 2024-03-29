﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.Abstraction;

namespace TelegramBotApi.Types.Requests
{
	class SendMessageRequest : BaseRequest
	{
		public long ChatId { get; set; }

		public string Text { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ParseMode
		{
			get => _parseMode?.ToString();
			set => 
				_parseMode = value == Types.ParseMode.None.ToString() 
				? null 
				: value;
		}
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool DisableWebPagePreview { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool DisableNotification { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public long ReplyToMessageId { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public IReplyMarkup ReplyMarkup { get; set; }

		private string _parseMode;

		public SendMessageRequest(long chatId, string text)
		{
			ChatId = chatId;
			Text = text;
		}
	}
}
