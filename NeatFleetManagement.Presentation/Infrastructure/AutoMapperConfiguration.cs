using AutoMapper;
using NeatFleetManagement.Presentation;
using NeatFleetManagement.Service;

namespace NeatFleetManagement.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new PresentationMappingProfile());
                c.AddProfile(new ServiceMappingProfile());
            });

            return config;
        }
    }
}