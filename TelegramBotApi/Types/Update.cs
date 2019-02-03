using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types.ReplyMarkup;

namespace TelegramBotApi.Types
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class Update
	{
		[JsonProperty("update_id")]
		public long Id { get; set; }

		public Message Message { get; set; }
		public CallbackQuery CallbackQuery { get; set; }

		public bool IsMessage()
		{
			return Message != null;
		}

		public bool IsCallbackQuery()
		{
			return CallbackQuery != null;
		}
	}
}
