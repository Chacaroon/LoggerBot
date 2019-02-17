using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApi.Types.Abstraction
{
	public interface IKeyboardButton
	{
		string Text { get; set; }
		string Url { get; set; }
		string CallbackData { get; set; }
	}
}
