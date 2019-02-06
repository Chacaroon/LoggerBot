using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.BLL.Interfaces.Models
{
	public interface IRequest
	{
		long ChatId { get; set; }
		long MessageId { get; set; }

		string Text { get; set; }

		Dictionary<string, string> Params { get; set; }
	}
}
