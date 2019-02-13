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
		private IRepository<App> _appRepository;
		private ITelegramBot _telegramBot;

		public OnSubscribeTokenCommand(
			IRepository<ApplicationUser> userRepository,
			IRepository<App> appRepository,
			ITelegramBot telegramBot)
		{
			_userRepository = userRepository;
			_appRepository = appRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			Guid subscribeToken;

			if (!Guid.TryParse(request.Text, out subscribeToken))
			{
				await SendIncorrectTokenResponse(request.ChatId);
				return;
			}

			var app = _appRepository
				.GetAll(a => a.SubscribeToken == subscribeToken)
				.FirstOrDefault();

			if (app.IsNullOrEmpty())
			{
				await SendIncorrectTokenResponse(request.ChatId);
				return;
			}

			var user = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.First();

			user.AddApp(app, true);

			_userRepository.Update(user);

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new SubscribeSuccessMessageTemplate(app.Name));

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
