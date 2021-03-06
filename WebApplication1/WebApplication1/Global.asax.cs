﻿using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RicoGMB;
using RicoGMB.Context;
using RicoGMB.Models;

namespace RicoGMB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var cntx = new RicoContext();
            Database.SetInitializer(new RicoDBConfiguration());
           
            cntx.Database.Initialize(true);
           
            //cntx.Database.Initialize(true);
           // var appcontext = new ApplicationDbContext();
           
        }
    }
}