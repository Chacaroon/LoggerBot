using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using TelegramBotApi;

namespace BLL.Commands
{
	class RemoveLoggerRequestCommand : BaseCommand, ICommand
	{
		private IRepository<ApplicationUser> _userRepository;

		public RemoveLoggerRequestCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;
			
			await SendResponse(
				request.ChatId,
				queryRequest.MessageId,
				new RemoveLoggerConfirmationMessageTemplate(queryRequest.Query.GetQueryParam("id")));
		}
	}
}
