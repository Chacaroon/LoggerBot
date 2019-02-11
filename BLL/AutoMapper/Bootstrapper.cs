using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.AutoMapper
{
	public class Bootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfile(new AbstractionToImplementationMappingProfile());
		}
	}
}
