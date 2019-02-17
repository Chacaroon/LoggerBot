using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TelegramLogger
{
	class ExceptionModel
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public ExceptionModel InnerException { get; set; }
		public DateTime DateTime { get; set; }

		public ExceptionModel()
		{
			DateTime = DateTime.UtcNow;
		}

		public StringContent ToHttpContent()
			=> new StringContent(
				JsonConvert.SerializeObject(this),
				Encoding.UTF8,
				"application/json");

	}
}
