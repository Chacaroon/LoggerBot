﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotApi.Types.ReplyMarkup
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class InlineKeyboardButton
	{
		public string Text { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Url { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CallbackData { get; set; }

		public InlineKeyboardButton(
			string text,
			string url = default,
			string callbackData = default)
		{
			Text = text;
			Url = url;
			CallbackData = callbackData;
		}
	}
}