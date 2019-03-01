using System;
using System.Linq;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System.Threading.Tasks;
using BLL.MessageTemplates;
using TelegramBotApi;

namespace BLL.Commands
{
	class ChangeLoggerNameRequestCommand : BaseCommand, ICommand
	{
		private IRepository<ApplicationUser> _userRepository;

		public ChangeLoggerNameRequestCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var user = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.First();

			user.ChatState.WaitingFor = $"ChangeLoggerName:id={queryRequest.Query.GetQueryParam("id")}";

			_userRepository.Update(user);

			await SendResponse(
				request.ChatId,
				new ChangeLoggerNameMessageTemplate());
		}
	}
}
