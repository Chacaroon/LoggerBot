using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace TelegramLogger
{
	public static class TelegramLoggerExtensions
	{
		public static ILoggerFactory AddTelegram(this ILoggerFactory factory, string token, Action<LoggerOptions> optionsBuilder)
		{
			var options = new LoggerOptions();

			optionsBuilder.Invoke(options);

			factory.AddProvider(new TelegramLoggerProvider(token, options));

			return factory;
		}

		public static ILoggerFactory AddTelegram(this ILoggerFactory factory, string token)
		{
			factory.AddProvider(new TelegramLoggerProvider(token, new LoggerOptions()));

			return factory;
		}
	}
}
