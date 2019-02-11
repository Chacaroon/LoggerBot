using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TelegramLogger
{
	class TelegramLogger : ILogger
	{
		private string _token;
		private LogLevel _logLevel;
		private HttpClient _httpClient;

		public TelegramLogger(string token, LogLevel logLevel)
		{
			_token = token;
			_logLevel = logLevel;
			_httpClient = new HttpClient();

			_httpClient.BaseAddress = new Uri("https://telegramloggingservice.azurewebsites.net/api/exception/");
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return null;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel >= _logLevel;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (formatter == null)
				throw new ArgumentNullException(nameof(formatter));

			if (!IsEnabled(logLevel)) return;

			var request = CreateExceptionModel(exception, formatter(state, exception));

			_httpClient.PostAsync($"{_token}", request.ToHttpContent()).Wait();
		}

		private ExceptionModel CreateExceptionModel(Exception exception, string message = default)
		{
			var exceptionModel = new ExceptionModel();

			exceptionModel.Message = message ?? exception.Message;
			exceptionModel.StackTrace = exception.StackTrace;

			if (exception.InnerException != null)
				exceptionModel.InnerException = CreateExceptionModel(exception.InnerException);

			return exceptionModel;
		}
	}
}
