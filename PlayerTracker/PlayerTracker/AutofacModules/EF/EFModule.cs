﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.AutofacModules.EF
{
    using Autofac;

    using Domain.Services;

    using global::EF;
    using global::EF.Models;
    using global::EF.Repository;
    using global::EF.Services;

    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new ApplicationDbContext()).As(typeof(ApplicationDbContext));
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<TrashCollectorService>().As(typeof(ITrashCollectorService)).InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As(typeof(ICustomerService)).InstancePerLifetimeScope();
            builder.RegisterType<TrashCollectionService>().As(typeof(ITrashCollectionService)).InstancePerLifetimeScope();
        }
    }
}