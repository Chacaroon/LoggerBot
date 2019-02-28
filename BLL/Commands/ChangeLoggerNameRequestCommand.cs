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
	class ChangeLoggerNameRequestCommand : ICommand
	{
		private IRepository<ApplicationUser> _userRepository;
		private ITelegramBot _telegramBot;

		public ChangeLoggerNameRequestCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
		{
			_userRepository = userRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var user = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.First();

			user.ChatState.WaitingFor = $"ChangeLoggerName:id={queryRequest.Query.GetQueryParam("id")}";

			_userRepository.Update(user);

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new ChangeLoggerNameMessageTemplate());

			res.EnsureSuccessStatusCode();
		}
	}
}
