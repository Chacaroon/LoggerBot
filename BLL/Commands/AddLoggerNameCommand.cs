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
			// TODO: Refactor AddLoggerCommand

			var user = _userRepository.GetAll(u => u.ChatId == request.ChatId).First();

			var app = new App(request.Text);

			user.AddApp(app);

			_userRepository.Update(user);

			var text = new StringBuilder()
				.AppendLine("Логгер успешно добавлен.")
				.AppendLine("Вот твой токен")
				.AppendLine($"`{app.PublicToken}`")
				.ToString();

			var res = await _telegramBot.SendMessageAsync(request.ChatId, 
				text, 
				parseMode: ParseMode.Markdown);

			res.EnsureSuccessStatusCode();
		}
	}
}
