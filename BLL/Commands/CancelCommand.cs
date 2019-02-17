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
	class CancelCommand : ICommand
	{
		private IRepository<ApplicationUser> _userRepository;
		private ITelegramBot _telegramBot;

		public CancelCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
		{
			_userRepository = userRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var user = _userRepository.GetAll(u => u.ChatId == request.ChatId).First();

			user.ChatState.IsWaitingFor = false;

			_userRepository.Update(user);

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				"Понял. Принял. Забыл.");

			res.EnsureSuccessStatusCode();
		}
	}
}
