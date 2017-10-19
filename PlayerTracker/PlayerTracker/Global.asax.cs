using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PlayerTracker
{
    using Autofac;
    using Autofac.Integration.Mvc;

    using TrashCollection.AutofacModules.Controllers;
    using TrashCollection.AutofacModules.EF;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeAutofac();
            
        }

        /// <summary>
        /// The initialize autofac.
        /// </summary>
        private void InitializeAutofac()
        {
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();

            builder.RegisterModule<EFModule>();
            builder.RegisterModule<ControllersModule>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
