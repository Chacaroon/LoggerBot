using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TelegramBotApi.Types.Requests
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class BaseRequest
	{
		public StringContent ToHttpContent()
		{
			return new StringContent(
				JsonConvert.SerializeObject(this),
				Encoding.UTF8,
				"application/json");
		}
	}
}
