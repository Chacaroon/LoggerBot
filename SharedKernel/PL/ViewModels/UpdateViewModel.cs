using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.PL.ViewModels
{
	[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
	public class UpdateViewModel
	{
		[JsonProperty("update_id")]
		public int Id { get; set; }

		public MessageViewModel Message { get; set; }
	}
}
