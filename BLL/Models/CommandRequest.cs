using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
	class CommandRequest : Request, ICommandRequest
	{
		public CommandRequest(long chatId, string text)
			: base(chatId, text)
		{ }
	}
}
