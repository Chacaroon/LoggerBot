using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class ShowSubscribeTokenCommand : ICommand
	{
		private IRepository<App> _appRepository;
		private ITelegramBot _telegramBot;

		public ShowSubscribeTokenCommand(
			IRepository<App> appRepository,
			ITelegramBot telegramBot)
		{
			_appRepository = appRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			if (!(request is IQueryRequest))
				throw new InvalidCastException($"{nameof(request)}");

			string appId = ((IQueryRequest)request).QueryParams.GetValueOrDefault("id");

			long id = long.Parse(appId);

			var token = _appRepository.FindById(id).SubscribeToken;

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new ShowSubscribeTokenMessageTemplate(token));

			res.EnsureSuccessStatusCode();
		}

		private async Task SendIncorrectTokenResponse(long chatId)
		{
			var res = await _telegramBot.SendMessageAsync(
				chatId,
				new IncorrectSubscribeTokenMessageTemplate());

			res.EnsureSuccessStatusCode();
		}
	}
}
