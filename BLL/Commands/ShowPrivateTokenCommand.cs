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
	class ShowPrivateTokenCommand : ICommand
	{
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public ShowPrivateTokenCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
		}
		
		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			string loggerId = ((IQueryRequest)request).QueryParams.GetValueOrDefault("id");

			long id = long.Parse(loggerId);

			var token = _loggerRepository.FindById(id).PrivateToken;

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new ShowPrivateTokenMessageTemplate(token));

			res.EnsureSuccessStatusCode();
		}
	}
}
