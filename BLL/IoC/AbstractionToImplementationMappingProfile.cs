using AutoMapper;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IoC
{
	class AbstractionToImplementationMappingProfile : Profile
	{
		public AbstractionToImplementationMappingProfile()
		{
			CreateMap<IExceptionInfo, ExceptionInfo>()
				.ForMember(e => e.Id, opt => opt.Ignore());
		}
	}
}
