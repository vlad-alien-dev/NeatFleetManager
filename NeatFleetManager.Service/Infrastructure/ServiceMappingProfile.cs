using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeatFleetManager.Data;

namespace NeatFleetManager.Service
{
	public class ServiceMappingProfile : Profile
	{
		public ServiceMappingProfile()
		{
			this.CreateMap<Car, CarServiceModel>();
			this.CreateMap<CarServiceModel, Car>();
			//.IncludeMembers(csh => csh.PLCPBase_CaseSpare);//TODO Consider using IncludeMembers
		}
	}
}