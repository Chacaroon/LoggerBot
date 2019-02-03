using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedKernel.Extensions
{
	public static class MatchStringExtension
	{
		public static bool IsMatch(this string str, string pattern)
		{
			return new Regex(pattern).IsMatch(str);
		}
	}
}
