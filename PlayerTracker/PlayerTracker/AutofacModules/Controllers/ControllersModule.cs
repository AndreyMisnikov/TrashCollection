using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.AutofacModules.Controllers
{
    using Autofac;
    using Autofac.Integration.Mvc;

    using PlayerTracker;
    using Module = Autofac.Module;

    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
        }
    }
}