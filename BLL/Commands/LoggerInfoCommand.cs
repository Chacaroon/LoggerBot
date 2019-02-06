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
	class LoggerInfoCommand : ICommand
	{
		private IRepository<App> _appRepository;
		private ITelegramBot _telegramBot;

		public LoggerInfoCommand(
			IRepository<App> appRepository,
			ITelegramBot telegramBot)
		{
			_appRepository = appRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var id = long.Parse(request.Params["id"]);

			var app = _appRepository.FindById(id);

			var text = new StringBuilder()
				.AppendLine($"*Имя*: {app.Name}")
				.AppendLine($"*Ошибок*: {app.Exceptions?.Count() ?? 0}")
				.ToString();

			var res = await _telegramBot.EditMessageAsync(
				request.ChatId,
				request.MessageId,
				text,
				parseMode: ParseMode.Markdown);

			res.EnsureSuccessStatusCode();
		}
	}
}
