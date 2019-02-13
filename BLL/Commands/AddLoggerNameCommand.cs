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
using TelegramBotApi.Types;

namespace BLL.Commands
{
	class AddLoggerNameCommand : ICommand
	{
		private IRepository<ApplicationUser> _userRepository;
		private ITelegramBot _telegramBot;

		public AddLoggerNameCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
		{
			_userRepository = userRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var user = _userRepository.GetAll(u => u.ChatId == request.ChatId).First();

			var app = new App(request.Text);

			user.AddApp(app);

			_userRepository.Update(user);

			await SendResponse(request.ChatId, app.PrivateToken);
		}

		private async Task SendResponse(long chatId, Guid token)
		{
			var res = await _telegramBot.SendMessageAsync(
				chatId,
				new AddLoggerSuccessMessageTemplate(token));

			res.EnsureSuccessStatusCode();
		}
	}
}
