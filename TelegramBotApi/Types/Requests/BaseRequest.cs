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
			var obj = JsonConvert.SerializeObject(this);
			return new StringContent(obj, Encoding.UTF8, "application/json");
		}
	}
}
