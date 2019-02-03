using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.BLL.Interfaces.CommandHandlers
{
	public interface ICommandsContainer
	{
		ICommand GetCommandHandler(string command);
	}
}
