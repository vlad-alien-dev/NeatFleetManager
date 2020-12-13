using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using NeatFleetManager.Data;
using NeatFleetManager.Service;
using NeatFleetManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NeatFleetManager.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            //builder.RegisterAssemblyTypes(typeof(Repository<Car>).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces().InstancePerRequest();
            // Services

            //builder.RegisterAssemblyTypes(typeof(CarService).Assembly)
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<Repository<Car>>().As<IRepository<Car>>().InstancePerRequest();
            builder.RegisterType<CarService>().As<ICarService>().InstancePerRequest();

            var mapper = AutoMapperConfiguration.Configure().CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
