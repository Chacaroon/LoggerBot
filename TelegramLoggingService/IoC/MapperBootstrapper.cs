using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLoggingService.IoC
{
	public class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfile(new ModelToEntityMappingProfile());

			BLL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
