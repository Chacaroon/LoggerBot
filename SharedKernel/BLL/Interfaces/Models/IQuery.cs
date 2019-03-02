using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.BLL.Interfaces.Models
{
	public interface IQuery
	{
		string GetCommand();
		Dictionary<string, string> GetQueryParams();
		string GetQueryParam(string param);
	}
}
