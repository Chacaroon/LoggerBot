using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegramLoggingService.WebhookConfig
{
	public static class WebhookConfigurator
	{
		public static void Configure(WebhookSettings settings)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri($"https://api.telegram.org/bot{settings.BotToken}/");

				var res = client.PostAsJsonAsync("setWebhook", new
				{
					url = settings.WebhookUri,
					allowed_updates = new[] { "message" }
				}).Result;

				res.EnsureSuccessStatusCode();
			}
		}
	}
}
