using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
	class QueryRequest : Request, IQueryRequest
	{
		public long MessageId { get; set; }
		public Dictionary<string, string> QueryParams { get; set; }


		public QueryRequest(long chatId, string text)
			: base(chatId, text)
		{ }

		public QueryRequest(
			long chatId, 
			long messageId, 
			string text, 
			Dictionary<string, string> queryParams)
			: this(chatId, text)
		{
			MessageId = messageId;
			QueryParams = queryParams;
		}
	}
}
