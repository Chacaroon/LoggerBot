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
	class ShowPrivateTokenCommand : BaseCommand, ICommand
	{
		private IRepository<Logger> _loggerRepository;

		public ShowPrivateTokenCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_loggerRepository = loggerRepository;
		}
		
		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			string loggerId = queryRequest.Query.GetQueryParam("id");

			long id = long.Parse(loggerId);

			var token = _loggerRepository.FindById(id).PrivateToken;

			await SendResponse(
				request.ChatId,
				new ShowPrivateTokenMessageTemplate(token));
		}
	}
}
