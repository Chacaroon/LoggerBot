using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SharedKernel.Exceptons
{
	public class InvalidTokenException : ApplicationException
	{
		public InvalidTokenException()
		{
		}

		public InvalidTokenException(string message) : base(message)
		{
		}

		public InvalidTokenException(Guid token)
			: base($"Logger with token {token} is not found")
		{
		}

		public InvalidTokenException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
