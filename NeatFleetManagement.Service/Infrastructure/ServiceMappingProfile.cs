using AutoMapper;
using NeatFleetManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManagement.Service
{
	public class ServiceMappingProfile : Profile
	{
		public ServiceMappingProfile()
		{
			this.CreateMap<Car, CarServiceModel>();
			this.CreateMap<CarServiceModel, Car>();
		}
	}
}