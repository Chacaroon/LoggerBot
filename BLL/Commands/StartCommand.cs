using BLL.Markups;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;
using TelegramBotApi.Types;
using DAL.Models;
using System.Linq;
using SharedKernel.DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace BLL.Commands
{
	public class StartCommand : ICommand
	{
		private ITelegramBot _telegramBot;
		private IRepository<DAL.Models.User> _userRepository;

		public StartCommand(ITelegramBot telegramBot, IRepository<DAL.Models.User> userRepository)
		{
			_telegramBot = telegramBot;
			_userRepository = userRepository;
		}

		public void Invoke(Message message)
		{
			_telegramBot.SendMessageAsync(message.Chat.Id, 
				$"Response to `/start`",
				ParseMode.Markdown, 
				replyMarkup: new StartMarkup());
		}
	}
}
