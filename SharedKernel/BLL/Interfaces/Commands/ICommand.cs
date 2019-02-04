using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;

namespace SharedKernel.BLL.Interfaces.Commands
{
	public interface ICommand
	{
		void Invoke(Message message);
	}
}
