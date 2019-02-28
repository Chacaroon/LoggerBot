using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
	class MessageRequest : Request, IMessageRequest
	{
		public IQuery Query { get; set; }

		public MessageRequest(
			long chatId,
			string text,
			string query)
			: base(chatId, text)
		{
			Query = new Query(query);
		}
	}
}
