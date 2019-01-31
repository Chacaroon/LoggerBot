using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SharedKernel.PL.ViewModels
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class UserViewModel
	{
		public long Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
	}
}