using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi.Types;

namespace SharedKernel.BLL.Interfaces.Commands
{
	public interface ICommand
	{
		Task Invoke(IRequest request);
	}
}
