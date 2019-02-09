using AutoMapper;
using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.DAL.Interfaces;
using SharedKernel.DAL.Models;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegramBotApi;

namespace BLL.Services
{
	public class ExceptionService : IExceptionService
	{
		private IRepository<App> _appRepository;
		private ITelegramBot _telegramBot;

		public ExceptionService(
			IRepository<App> appRepository,
			ITelegramBot telegramBot)
		{
			_appRepository = appRepository;
			_telegramBot = telegramBot;
		}

		public void HandleException(Guid id, IExceptionInfo exceptionInfo)
		{
			// TODO: Refactor this service

			var app = _appRepository.GetAll(a => a.PublicToken == id).FirstOrDefault();

			if (app.IsNullOrEmpty())
			{
				// TODO: Handle incorrect app id exception
				return;
			}

			app.Exceptions = app.Exceptions.Append(Mapper.Map<ExceptionInfo>(exceptionInfo)).ToList();

			_appRepository.Update(app);

			var message = new ExceptionInfoMessageTemplate(
				app.Name,
				exceptionInfo.Message,
				exceptionInfo.StackTrace);

			foreach (var userApp in app.UserApps)
			{
				var chatId = userApp.User.ChatId;

				_telegramBot.SendMessageAsync(chatId, message).Wait();
			}
		}
	}
}
