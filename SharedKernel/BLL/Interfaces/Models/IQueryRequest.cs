﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.BLL.Interfaces.Models
{
	public interface IQueryRequest : IRequest
	{
		long MessageId { get; set; }
		IQuery Query { get; set; }
	}
}
