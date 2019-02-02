﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types.Abstraction;

namespace TelegramBotApi
{
	public interface ITelegramBot
	{
		Task<HttpResponseMessage> SetWebhook(
			string webhookUri,
			string[] allowedUpdates = default);

		Task<HttpResponseMessage> SendMessageAsync(
			long chatId,
			string text,
			string parseMode = default,
			bool disableWebPagePreview = default,
			bool disableNotification = default,
			long replyToMessageId = default,
			IReplyMarkup replyMarkup = default);
	}
}