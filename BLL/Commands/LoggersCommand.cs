﻿using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.Commands
{
	class LoggersCommand : ICommand
	{
		private ITelegramBot _telegramBot;
		private IRepository<ApplicationUser> _userRepository;

		public LoggersCommand(
			ITelegramBot telegramBot,
			IRepository<ApplicationUser> userRepository)
		{
			_telegramBot = telegramBot;
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var apps = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.SelectMany(u => u.UserApps.Select(ua => ua.App));

			var appsMarkup = new InlineKeyboardMarkup();

			foreach (var app in apps)
			{
				appsMarkup.AddRow(new InlineKeyboardButton(app.Name, callbackData: $"loggerInfo:id={app.Id}"));
			}

			appsMarkup.AddRow(new InlineKeyboardButton("<< Назад", callbackData: "menu"));

			var res = await _telegramBot.EditMessageAsync(request.ChatId,
				request.MessageId,
				"Это все твои логгеры",
				replyMarkup: appsMarkup);

			var response = res.Content.ReadAsStringAsync();

			res.EnsureSuccessStatusCode();
		}
	}
}