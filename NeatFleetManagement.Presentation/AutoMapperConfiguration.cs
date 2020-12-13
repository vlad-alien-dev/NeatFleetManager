using AutoMapper;
using NeatFleetManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeatFleetManager.Web.Infrastructure
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