using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	public class AddLoggerCommand : ICommand
	{
		private ITelegramBot _telegramBot;
		private IRepository<ApplicationUser> _userRepository;

		public AddLoggerCommand(
			ITelegramBot telegramBot,
			IRepository<ApplicationUser> userRepository)
		{
			_telegramBot = telegramBot;
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new AddLoggerNameMessageTemplate());

			res.EnsureSuccessStatusCode();

			var user = _userRepository.GetAll(u => u.ChatId == request.ChatId).First();

			user.ChatState.WaitingFor = "AddLoggerName";

			_userRepository.Update(user);
		}
	}
}
