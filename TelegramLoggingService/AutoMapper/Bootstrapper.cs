using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLoggingService.AutoMapper
{
	public class Bootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfile(new ModelToEntityMappingProfile());

			BLL.AutoMapper.Bootstrapper.Bootstrap(cfg);
		}
	}
}
