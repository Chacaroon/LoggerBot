using BLL.MessageTemplates;
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
	class OnSubscribeTokenCommand : ICommand
	{
		private IRepository<ApplicationUser> _userRepository;
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public OnSubscribeTokenCommand(
			IRepository<ApplicationUser> userRepository,
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_userRepository = userRepository;
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
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

			user.AddLogger(logger, true);

			_userRepository.Update(user);

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new SubscribeSuccessMessageTemplate(logger.Name));

			res.EnsureSuccessStatusCode();
		}

		private async Task SendIncorrectTokenResponse(long chatId)
		{
			var res = await _telegramBot.SendMessageAsync(
				chatId,
				"Некорректный Subscribe Token");

			res.EnsureSuccessStatusCode();
		}
	}
}
