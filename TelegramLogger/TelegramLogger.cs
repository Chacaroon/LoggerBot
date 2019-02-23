using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

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
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(AppSettings.ApiUri)
			};
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

			if (exception.Source == "Microsoft.Extensions.Logging") return;

			var request = CreateExceptionModel(exception, formatter(state, exception));

			HttpResponseMessage res = _httpClient.PostAsync($"{_token}", request.ToHttpContent()).Result;
			var responseMessage = res.Content.ReadAsStringAsync().Result;

			try
			{
				res.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException)
			{
				throw new LoggerException(responseMessage);
			}
		}

		private ExceptionModel CreateExceptionModel(Exception exception, string message = default)
		{
			var exceptionModel = new ExceptionModel
			{
				Message = message ?? exception.Message,
				StackTrace = exception.StackTrace
			};

			if (exception.InnerException != null)
				exceptionModel.InnerException = CreateExceptionModel(exception.InnerException);

			return exceptionModel;
		}
	}
}
