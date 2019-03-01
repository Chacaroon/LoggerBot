using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.MessageTemplates;
using TelegramBotApi;

namespace BLL.Commands
{
	class CancelCommand : BaseCommand, ICommand
	{
		private IRepository<ApplicationUser> _userRepository;

		public CancelCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var user = _userRepository.GetAll(u => u.ChatId == request.ChatId).First();

			user.ChatState.IsWaitingFor = false;

			_userRepository.Update(user);

			await SendResponse(request.ChatId, new CancleMessageTemplate());
		}
	}
}
