using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class SubscribeInfoCommand : ICommand
	{
		private IRepository<App> _appRepository;
		private ITelegramBot _telegramBot;

		public SubscribeInfoCommand(IRepository<App> appRepository,
			ITelegramBot telegramBot)
		{
			_appRepository = appRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			if (!(request is IQueryRequest))
				throw new InvalidCastException(nameof(request));

			var queryRequest = (IQueryRequest)request;

			var appId = long.Parse(queryRequest.QueryParams.GetValueOrDefault("id"));

			var app = _appRepository.FindById(appId);

			if (app.IsNullOrEmpty())
				throw new KeyNotFoundException(nameof(app));

			var res = await _telegramBot.EditMessageAsync(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new SubscribeInfoMessageTemplate(app.Name, app.Exceptions?.Count() ?? 0));

			res.EnsureSuccessStatusCode();
		}
	}
}
