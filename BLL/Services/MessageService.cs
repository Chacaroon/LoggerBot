using BLL.Models;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.DAL.Interfaces;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types;

namespace BLL.Services
{
	public class MessageService : IMessageService
	{
		private IEnumerable<ICommand> _commands;
		private IRepository<ApplicationUser> _userRepository;

		public MessageService(
			IEnumerable<ICommand> commands,
			IRepository<ApplicationUser> userRepository)
		{
			_commands = commands;
			_userRepository = userRepository;
		}

		public async Task HandleRequest(Message message)
		{
			if (message.IsCommand())
			{
				await ProcessAsCommand(message);
				return;
			}

			await ProcessAsText(message);
		}

		private async Task ProcessAsCommand(Message message)
		{
			var command = _commands.GetCommandOrDefault(message.GetCommand());

			var request = new CommandRequest(
				message.Chat.Id,
				message.Text);

			try
			{
				await command.Invoke(request);
			}
			catch
			{
				await _commands.GetErrorCommand().Invoke(request);
			}
		}

		private async Task ProcessAsText(Message message)
		{
			var user = _userRepository.GetAll(u => u.ChatId == message.Chat.Id).FirstOrDefault();
			
			if (user.IsNullOrEmpty())
			{
				var tempRequest = new Request(message.Chat.Id, message.Text);

				await _commands.GetErrorCommand().Invoke(tempRequest);
				return;
			}

			if (!user.ChatState.IsWaitingFor)
			{
				var tempRequest = new Request(message.Chat.Id, message.Text);

				await _commands.GetUndefinedCommand().Invoke(tempRequest);
				return;
			}

			var request = new MessageRequest(
				message.Chat.Id,
				message.Text,
				user.ChatState.WaitingFor);

			ICommand command = _commands.GetCommandOrDefault(request.Query.GetCommand());

			try
			{
				command.Invoke(request).Wait();
			}
			catch
			{
				_commands.GetErrorCommand().Invoke(request).Wait();
			}
			finally
			{
				user.ChatState.IsWaitingFor = false;
				_userRepository.Update(user);
			}
		}
	}
}
