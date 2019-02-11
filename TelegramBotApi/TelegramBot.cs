using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types;
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
			ParseMode parseMode,
			bool disableWebPagePreview,
			bool disableNotification,
			long replyToMessageId,
			IReplyMarkup replyMarkup) 
			
			=> MakeRequest("sendMessage",
				new SendMessageRequest(chatId, text)
				{
					ParseMode = parseMode.ToString(),
					DisableWebPagePreview = disableWebPagePreview,
					DisableNotification = disableNotification,
					ReplyToMessageId = replyToMessageId,
					ReplyMarkup = replyMarkup
				});

		public Task<HttpResponseMessage> SendMessageAsync(
			long chatId,
			IMessageTemplate messageTemplate,
			bool disableWebPagePreview,
			bool disableNotification,
			long replyToMessageId)

			=> MakeRequest("sendMessage",
				new SendMessageRequest(chatId, messageTemplate.Text)
				{
					ParseMode = messageTemplate.ParseMode.ToString(),
					DisableWebPagePreview = disableWebPagePreview,
					DisableNotification = disableNotification,
					ReplyToMessageId = replyToMessageId,
					ReplyMarkup = messageTemplate.ReplyMarkup
				});

		public Task<HttpResponseMessage> EditMessageAsync(
			long chatId,
			long messageId,
			string text,
			ParseMode parseMode,
			bool disableWebPagePreview,
			IReplyMarkup replyMarkup)

			=> MakeRequest("editMessageText",
				new EditMessageRequest(chatId, messageId, text)
				{
					ParseMode = parseMode.ToString(),
					DisableWebPagePreview = disableWebPagePreview,
					ReplyMarkup = replyMarkup
				});

		public Task<HttpResponseMessage> EditMessageAsync(
			long chatId,
			long messageId,
			IMessageTemplate messageTemplate,
			bool disableWebPagePreview)

			=> MakeRequest("editMessageText",
				new EditMessageRequest(chatId, messageId, messageTemplate.Text)
				{
					ParseMode = messageTemplate.ParseMode.ToString(),
					DisableWebPagePreview = disableWebPagePreview,
					ReplyMarkup = messageTemplate.ReplyMarkup
				});

		public Task<HttpResponseMessage> AnswerCallbackQuery(
			string callbackQueryId,
			string text)

			=> MakeRequest("answerCallbackQuery",
				new AnswerCallbackQueryRequest(callbackQueryId)
				{
					Text = text
				});
	}
}
