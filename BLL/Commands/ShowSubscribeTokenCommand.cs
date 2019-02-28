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
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public ShowSubscribeTokenCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			string loggerId = queryRequest.Query.GetQueryParam("id");

			long id = long.Parse(loggerId);

			var token = _loggerRepository.FindById(id).SubscribeToken;

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
