﻿using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
	class QueryRequest : Request, IQueryRequest
	{
		public long MessageId { get; set; }
		public IQuery Query { get; set; }

		public QueryRequest(
			long chatId, 
			long messageId, 
			string text)
			: base(chatId, text)
		{
			MessageId = messageId;
			Query = new Query(text);
		}
	}
}
