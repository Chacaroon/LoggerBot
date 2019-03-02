using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramLogger
{
	class TelegramLoggerProvider : ILoggerProvider
	{
		private string _token;
		private LoggerOptions _options;

		public TelegramLoggerProvider(string token, LoggerOptions options)
		{
			_token = token;
			_options = options;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new TelegramLogger(_token, _options);
		}

		public void Dispose()
		{
		}
	}
}
