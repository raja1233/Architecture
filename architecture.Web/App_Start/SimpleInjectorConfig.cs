using architecture.Service.Abstract;
using architecture.Service.FunctionServices;
using architecture.Data.Repository;
using architecture.Entity;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using SimpleInjector.Lifestyles;
using architecture.Data;
using SimpleInjector.Integration.WebApi;
using architecture.Data.Infrastructure;
using System.Data.Entity;

namespace architecture.Web.App_Start
{
    public class SimpleInjectorConfig
    {
       
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new Container()));  
        }
        public static void Initialize(HttpConfiguration config, Container container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        public static Container RegisterServices(Container container)
        {
            //Create a dependency controller
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Registering types, for instance using the scoped lifestyle:

            container.Register<DbContext, PersonContext>(Lifestyle.Scoped);
            //DbContext context = container.GetInstance<DbContext>();

            //container.Register(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>), (Lifestyle.Scoped));

            container.Register(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepositoty<>), Lifestyle.Scoped);
            //var addons = container.GetAllInstances<IEntityBaseRepository<Addons>>();

            container.Register<IDbFactory, DbFactory>(Lifestyle.Scoped);
            //var dbfactory = container.GetInstance<IDbFactory>();
            //container.Register<ISQLSPHelper, SQLSPHelper>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            //var unitOfWork =  container.GetInstance<IUnitOfWork>();

            container.Register<IFunction, FService>(Lifestyle.Scoped);
            //var commonService = container.GetInstance<ICommonService>();

            //var addonsService = container.GetInstance<IAddonsService>();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            // This two extension method from integration package
            return container;
        }
    }
}