using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TelegramBotApi.Types.ReplyMarkup;

namespace SharedKernel.Extensions
{
	public static class CallbackQueryParserExtension
	{
		public static string GetCommand(this CallbackQuery callbackQuery)
		{
			var match = new Regex(@"^(?i)([a-z]+):?").Match(callbackQuery.Data);

			return match.Groups[1].Value;
		}

		public static Dictionary<string, string> GetQueryParams(this CallbackQuery callbackQuery)
		{
			var _params = new Dictionary<string, string>();

			var match = new Regex(@"(?i)[a-z]+:?(?:([a-z]+)=([^,]+),?)*").Match(callbackQuery.Data);

			for (var i = 0; i < match.Groups[1].Captures.Count; i++)
			{
				_params.Add(match.Groups[1].Captures[i].Value,
					match.Groups[2].Captures[i].Value);
			}

			return _params;
		}
	}
}
