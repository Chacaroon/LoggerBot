﻿using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class OnSubscribeTokenCommand : BaseCommand, ICommand
	{
		private IRepository<ApplicationUser> _userRepository;
		private IRepository<Logger> _loggerRepository;

		public OnSubscribeTokenCommand(
			IRepository<ApplicationUser> userRepository,
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_userRepository = userRepository;
			_loggerRepository = loggerRepository;
		}

		public async Task Invoke(IRequest request)
		{
			if (!Guid.TryParse(request.Text, out Guid subscribeToken))
			{
				await SendIncorrectTokenResponse(request.ChatId);
				return;
			}

			var logger = _loggerRepository
				.GetAll(a => a.SubscribeToken == subscribeToken)
				.FirstOrDefault();

			if (logger.IsNullOrEmpty())
			{
				await SendIncorrectTokenResponse(request.ChatId);
				return;
			}

			var user = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.First();

			var isUserAlreadySubscribed = user
				                              .UserLoggers
				                              .Where(ul => ul.Logger.SubscribeToken == subscribeToken)
				                              .Count() > 0;

			if (isUserAlreadySubscribed)
			{
				await SendIncorrectTokenResponse(request.ChatId);
				return;
			}

			user.AddLogger(logger, true);

			_userRepository.Update(user);

			await SendResponse(
				request.ChatId,
				new SubscribeSuccessMessageTemplate(logger.Name));
		}

		private async Task SendIncorrectTokenResponse(long chatId)
		{
			await SendResponse(
				chatId,
				new IncorrectSubscribeToken());
		}
	}
}
