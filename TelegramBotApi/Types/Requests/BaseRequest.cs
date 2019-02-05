using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TelegramBotApi.Types.Requests
{
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
