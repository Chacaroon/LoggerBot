using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types;

namespace SharedKernel.BLL.Interfaces.Services
{
	public interface IMessageService
	{
		Task HandleRequest(Message message);
	}
}
