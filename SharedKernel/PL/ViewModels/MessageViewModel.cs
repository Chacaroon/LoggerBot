using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace SharedKernel.PL.ViewModels
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class MessageViewModel
	{
		public long MessageId { get; set; }

		public UserViewModel From { get; set; }
		public ChatViewModel Chat { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }
	}
}