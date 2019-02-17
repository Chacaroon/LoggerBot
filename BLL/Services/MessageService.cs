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

		public void HandleRequest(Message message)
		{
			if (message.IsCommand())
			{
				ProcessAsCommand(message);
				return;
			}

			ProcessAsText(message);
		}

		private void ProcessAsCommand(Message message)
		{
			var command = _commands.GetCommandOrDefault(message.GetCommand());

			var request = new CommandRequest(
				message.Chat.Id,
				message.Text);

			try
			{
				command.Invoke(request).Wait();
			}
			catch
			{
				_commands.GetErrorCommand().Invoke(request).Wait();
			}
		}

		private void ProcessAsText(Message message)
		{
			var user = _userRepository.GetAll(u => u.ChatId == message.Chat.Id).FirstOrDefault();

			var request = new Request(
				message.Chat.Id,
				message.Text);

			if (user.IsNullOrEmpty())
			{
				_commands.GetErrorCommand().Invoke(request).Wait();
				return;
			}

			var command = _commands.GetCommandOrDefault(user.ChatState.WaitingFor);

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
