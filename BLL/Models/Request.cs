using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
	public class Request : IRequest
	{
		public long ChatId { get; set; }
		public long MessageId { get; set; }

		public string Text { get; set; }

		public Request(long chatId, string text, long messageId = default)
		{
			ChatId = chatId;
			MessageId = messageId;
			Text = text;
		}
	}
}
