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
			var command = _commands.GetCommand(message.GetCommand())
				?? _commands.GetCommand("undefined");

			var request = new Request(
				message.Chat.Id,
				message.Text);

			try
			{
				command.Invoke(request).Wait();
			} 
			catch
			{
				//TODO: Handle errors
			}
		}

		private void ProcessAsText(Message message)
		{
			var user = _userRepository.GetAll(u => u.ChatId == message.Chat.Id).First();
			ICommand command;

			if (!user.ChatState.IsWaitingFor)
				command = _commands.GetCommand("undefinde");
			else
				command = _commands.GetCommand(user.ChatState.WaitingFor);

			var request = new Request(
				message.Chat.Id,
				message.Text);

			try
			{
				command.Invoke(request).Wait();
			}
			catch
			{
				// TODO: Handle exceptions
			}
		}
	}
}
