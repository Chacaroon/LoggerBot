using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.BLL.Interfaces.Models
{
	public interface IMessageRequest : IRequest
	{
		IQuery Query { get; set; }
	}
}
