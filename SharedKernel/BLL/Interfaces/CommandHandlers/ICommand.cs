using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;

namespace SharedKernel.BLL.Interfaces.CommandHandlers
{
	public interface ICommand
	{
		void Invoke(Message message);
	}
}
