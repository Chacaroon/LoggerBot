using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBotApi;

namespace TelegramLoggingService.IoC
{
	public static class ServiceProvider
	{
		public static void AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpClient<ITelegramBot, TelegramBot>(configureClient =>
			{
				configureClient.BaseAddress = new Uri(String.Format("https://api.telegram.org/bot{0}/", configuration["TelegramBotSettings:BotToken"]));
			});
		}
	}
}
