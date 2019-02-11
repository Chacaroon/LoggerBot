using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApi.Types.Requests
{
	public class AnswerCallbackQueryRequest : BaseRequest
	{
		public string CallbackQueryId { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Text { get; set; }

		public AnswerCallbackQueryRequest(string callbackQueryId)
		{
			CallbackQueryId = callbackQueryId;
		}
	}
}
