using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApi.Types.Requests
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	class SetWebhookReqest : BaseRequest
	{
		public string Url { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string[] AllowedUpdates { get; set; }

		public SetWebhookReqest(string url, string[] allowedUpdates)
		{
			Url = url;
			AllowedUpdates = allowedUpdates;
		}
	}
}
