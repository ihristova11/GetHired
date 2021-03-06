﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using GetHired.ASPClient.Identity_Providers;
using GetHired.DataModels.Models;
using GetHired.DataModels.Configurations;
using IdentityDemoWithIoC;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GetHired.ASPClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<GetHiredContext>(new InitialDataConfiguration());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Configure();

            AutofacConfig.Configure();
        }
    }
}