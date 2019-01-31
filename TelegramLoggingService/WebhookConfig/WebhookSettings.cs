using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLoggingService.WebhookConfig
{
	public class WebhookSettings
	{
		public string BotToken { get; set; }
		public string WebhookUri { get; set; }

		public WebhookSettings(string botToken, string webhookUri)
		{
			BotToken = botToken;
			WebhookUri = webhookUri;
		}
	}
}
