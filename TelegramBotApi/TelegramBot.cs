using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types.Abstraction;
using TelegramBotApi.Types.Requests;

namespace TelegramBotApi
{
	public class TelegramBot : ITelegramBot
	{
		private HttpClient _client { get; set; }

		public TelegramBot(HttpClient client)
		{
			_client = client;
		}

		private Task<HttpResponseMessage> MakeRequest(string url, BaseRequest obj) 
			
			=> _client.PostAsync(url, obj.ToHttpContent());

		public Task<HttpResponseMessage> SetWebhook(
			string webhookUri,
			string[] allowedUpdates = default)
			
			=> MakeRequest("setWebhook", new SetWebhookReqest(webhookUri, allowedUpdates));

		public Task<HttpResponseMessage> SendMessageAsync(
			long chatId,
			string text,
			string parseMode,
			bool disableWebPagePreview,
			bool disableNotification,
			long replyToMessageId,
			IReplyMarkup replyMarkup) 
			
			=> MakeRequest("sendMessage",
				new SendMessageRequest(chatId, text)
				{
					ParseMode = parseMode,
					DisableWebPagePreview = disableWebPagePreview,
					DisableNotification = disableNotification,
					ReplyToMessageId = replyToMessageId,
					ReplyMarkup = replyMarkup
				});
	}
}
