using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IoC
{
	public class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfile(new AbstractionToImplementationMappingProfile());
		}
	}
}
