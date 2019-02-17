using AutoMapper;
using AutoMapper.Configuration;
using BLL.Services;
using DAL.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.BLL.Interfaces.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;

namespace BLL.IoC
{
	public class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<IMessageService, MessageService>(Lifestyle.Transient);
			container.Register<ICallbackQueryService, CallbackQueryService>(Lifestyle.Transient);
			container.Register<IExceptionService, ExceptionService>(Lifestyle.Transient);

			CommandBootstrapper.Bootstrap(container);

			DAL.IoC.Bootstrapper.Bootstrap(container);
		}
	}
}
