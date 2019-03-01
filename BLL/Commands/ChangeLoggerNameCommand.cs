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
	class ChangeLoggerNameCommand : BaseCommand, ICommand
	{
		private IRepository<Logger> _loggerRepository;

		public ChangeLoggerNameCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_loggerRepository = loggerRepository;
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

			await SendResponse(
				request.ChatId,
				new ChangeLoggerNameSuccessMessageTemplate());
		}
	}
}
