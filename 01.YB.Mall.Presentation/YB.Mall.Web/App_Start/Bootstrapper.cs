using System.ComponentModel.Design;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;
using YB.Mall.Service;
namespace YB.Mall.Web
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
        }

        private static void ConfigureAutofacContainer()
        {
            var webContainerBuilder = new ContainerBuilder();
            ConfigureWebApiContainer(webContainerBuilder);
        }

        private static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerRequest();
            //containerBuilder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>().AsImplementedInterfaces().InstancePerRequest();
            //containerBuilder.RegisterType<UserInfoService>().As<IUserInfoService>().InstancePerRequest();
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterAssemblyTypes(Assembly.Load("YB.Mall.Service")).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(Assembly.Load("YB.Mall.Data")).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}