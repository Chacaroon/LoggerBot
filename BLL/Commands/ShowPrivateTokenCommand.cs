using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class ShowPrivateTokenCommand : ICommand
	{
		private IRepository<App> _appRepository;
		private ITelegramBot _telegramBot;

		public ShowPrivateTokenCommand(
			IRepository<App> appRepository,
			ITelegramBot telegramBot)
		{
			_appRepository = appRepository;
			_telegramBot = telegramBot;
		}
		
		public async Task Invoke(IRequest request)
		{
			if (!(request is IQueryRequest))
				throw new InvalidCastException($"{nameof(request)} is not {nameof(IQueryRequest)}");

			string appId = ((IQueryRequest)request).QueryParams.GetValueOrDefault("id");

			long id = long.Parse(appId);

			var token = _appRepository.FindById(id).PrivateToken;

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new ShowPrivateTokenMessageTemplate(token));

			res.EnsureSuccessStatusCode();
		}
	}
}
