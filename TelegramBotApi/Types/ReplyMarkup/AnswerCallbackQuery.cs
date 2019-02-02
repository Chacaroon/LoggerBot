using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApi.Types.ReplyMarkup
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class AnswerCallbackQuery
	{
		public string CallbackQueryId { get; set; }
		public string Text { get; set; }
	}
}
