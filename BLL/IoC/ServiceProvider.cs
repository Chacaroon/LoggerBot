using BLL.Services;
using DAL.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;

namespace BLL.IoC
{
	public static class ServiceProvider
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddTransient<IMessageService, MessageService>();
			services.AddTransient<ICallbackQueryService, CallbackQueryService>();

			services.AddRepositories();
		}
	}
}
