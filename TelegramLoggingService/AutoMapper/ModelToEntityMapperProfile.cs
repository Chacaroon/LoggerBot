using AutoMapper;
using BLL.Models;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramLoggingService.ViewModels;

namespace TelegramLoggingService.AutoMapper
{
	public class ModelToEntityMappingProfile : Profile
	{
		public ModelToEntityMappingProfile()
		{
			CreateMap<ExceptionViewModel, IExceptionInfo>()
				.ForMember(evm => evm.Id, opt => opt.Ignore())
				.ForMember(evm => evm.CreatedAt, opt => opt.Ignore());
		}
	}
}
