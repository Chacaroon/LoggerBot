using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.BLL.Interfaces.Services
{
	public interface IExceptionService
	{
		void HandleException(Guid id, IExceptionInfo exceptionInfo);
	}
}
