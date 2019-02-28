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
	class ChangeLoggerNameCommand : ICommand
	{
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public ChangeLoggerNameCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var messageRequest = (IMessageRequest)request;

			var loggerId = long.Parse(messageRequest.Query.GetQueryParam("id"));

			var logger = _loggerRepository
				.GetAll(l => l.Id == loggerId)
				.First();

			logger.Name = request.Text;

			_loggerRepository.Update(logger);

			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				new ChangeLoggerNameSuccessMessageTemplate());

			res.EnsureSuccessStatusCode();
		}
	}
}
