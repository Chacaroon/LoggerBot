using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramLogger
{
	public static class TelegramLoggerExtensions
	{
		public static ILoggerFactory AddTelegram(this ILoggerFactory factory, string token)
		{
			factory.AddTelegram(token, LogLevel.Warning);

			return factory;
		}

		public static ILoggerFactory AddTelegram(this ILoggerFactory factory, string token, LogLevel minLevel)
		{
			factory.AddProvider(new TelegramLoggerProvider(token, minLevel));

			return factory;
		}
	}
}
