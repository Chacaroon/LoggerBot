using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace TelegramBotApi.Types
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class Message
	{
		[JsonProperty("message_id")]
		public long Id { get; set; }

		public User From { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }
		public Chat Chat { get; set; }
		public string Text { get; set; }

	}
}