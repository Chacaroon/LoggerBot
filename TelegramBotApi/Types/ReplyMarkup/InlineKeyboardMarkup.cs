using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegramBotApi.Types.Abstraction;

namespace TelegramBotApi.Types.ReplyMarkup
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class InlineKeyboardMarkup : IReplyMarkup
	{
		public List<IEnumerable<IKeyboardButton>> InlineKeyboard { get; set; }

		public InlineKeyboardMarkup()
		{
			InlineKeyboard = new List<IEnumerable<IKeyboardButton>>();
		}

		public IReplyMarkup AddRow(params IKeyboardButton[] buttons)
		{
			InlineKeyboard.Add(buttons);
			return this;
		}
	}
}
