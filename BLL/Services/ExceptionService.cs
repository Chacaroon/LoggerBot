using AutoMapper;
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
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public ExceptionService(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
		}

		public void HandleException(Guid id, IExceptionInfo exceptionInfo)
		{
			var logger = _loggerRepository.GetAll(a => a.PrivateToken == id).FirstOrDefault();

			if (logger.IsNullOrEmpty())
			{
				throw new KeyNotFoundException();
			}

			logger.AddException(Mapper.Map<ExceptionInfo>(exceptionInfo));

			_loggerRepository.Update(logger);

			SendResponse(logger.Name, logger.UserLoggers, logger.Exceptions.Last());
		}

		private void SendResponse(string appName, IEnumerable<UserLogger> userLoggers, ExceptionInfo exceptionInfo)
		{
			var message = new ExceptionInfoMessageTemplate(
				appName,
				exceptionInfo.Message,
				exceptionInfo.StackTrace);

			foreach (var userLogger in userLoggers)
			{
				_telegramBot.SendMessageAsync(userLogger.User.ChatId, message).Wait();
			}
		}
	}
}
