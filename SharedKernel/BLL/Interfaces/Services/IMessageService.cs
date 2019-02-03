using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;

namespace SharedKernel.BLL.Interfaces.Services
{
	public interface IMessageService
	{
		void HandleMessage(Message message);
	}
}
