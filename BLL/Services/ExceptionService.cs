﻿using AutoMapper;
using BLL.MessageTemplates;
using DAL.Models;
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
			var app = _appRepository.GetAll(a => a.PrivateToken == id).FirstOrDefault();

			if (app.IsNullOrEmpty())
			{
				// TODO: Handle incorrect app id exception
				return;
			}

			app.AddException(Mapper.Map<ExceptionInfo>(exceptionInfo));

			_appRepository.Update(app);

			SendResponse(app.Name, app.UserApps, app.Exceptions.Last());
		}

		private void SendResponse(string appName, IEnumerable<UserApp> userApps, ExceptionInfo exceptionInfo)
		{
			var message = new ExceptionInfoMessageTemplate(
				appName,
				exceptionInfo.Message,
				exceptionInfo.StackTrace);

			foreach (var userApp in userApps)
			{
				_telegramBot.SendMessageAsync(userApp.User.ChatId, message).Wait();
			}
		}
	}
}