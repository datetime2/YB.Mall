using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YB.Mall.Data;
using YB.Mall.Core;
using YB.Mall.Core.Plugins;

namespace YB.Mall.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Configure();
            AreaRegistration.RegisterAllAreas();
            //数据库自动映射
            //Database.SetInitializer(new MallDbInitializer());

            PluginsManagement.RegistAtStart();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
