using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using SharedKernel.Extensions;
using SharedKernel.BLL.Interfaces.Models;
using BLL.MessageTemplates;

namespace BLL.Commands
{
	public class StartCommand : BaseCommand, ICommand
	{
		private IRepository<ApplicationUser> _userRepository;

		public StartCommand(
			ITelegramBot telegramBot,
			IRepository<ApplicationUser> userRepository)
			: base(telegramBot)
		{
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			await SendResponse(
				request.ChatId,
				new StartMessageTemplate());

			if (IsUserExisted(request.ChatId))
				AddUserToDatabase(request.ChatId);
		}

		private void AddUserToDatabase(long chatId)
		{
			var user = new ApplicationUser(chatId);

			_userRepository.Add(user);
		}

		private bool IsUserExisted(long chatId)
			=> _userRepository.GetAll(u => u.ChatId == chatId).FirstOrDefault().IsNullOrEmpty();
	}
}
