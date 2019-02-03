using BLL;
using BLL.CommandHandlers;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.BLL.Interfaces;
using SharedKernel.BLL.Interfaces.Services;
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

			services.AddTransient<IMessageService, MessageService>();
			services.AddTransient<ICallbackQueryService, CallbackQueryService>();
		}
	}
}
