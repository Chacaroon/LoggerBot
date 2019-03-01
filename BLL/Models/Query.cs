using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SharedKernel.Extensions;
using TelegramBotApi.Types.Abstraction;

namespace BLL.Models
{
	class Query : IQuery
	{
		private string _text;

		public Query(string text)
		{
			_text = text;
		}

		public string GetCommand()
		{
			if (_text.IsNullOrEmpty()) return "";

			var match = new Regex(@"^(?i)([a-z]+):?").Match(_text);

			return match.Groups[1].Value;
		}

		public Dictionary<string, string> GetQueryParams()
		{
			var _params = new Dictionary<string, string>();

			var match = new Regex(@"(?i)[a-z]+:?(?:([a-z]+)=([^,]+),?)*").Match(_text);

			for (var i = 0; i < match.Groups[1].Captures.Count; i++)
			{
				_params.Add(match.Groups[1].Captures[i].Value,
					match.Groups[2].Captures[i].Value);
			}

			return _params;
		}

		public string GetQueryParam(string param)
		{
			return GetQueryParams().GetValueOrDefault(param);
		}
	}
}
