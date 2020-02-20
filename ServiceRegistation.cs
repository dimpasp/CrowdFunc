using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CrowdFun.Core.model.services;

namespace CrowdFun.Core
{
    public class ServiceRegistation
    {        
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            if (builder == null) {
                throw new ArgumentNullException(nameof(builder));
            }

            builder
                .RegisterType<BackerServices>()
                .InstancePerLifetimeScope()
                .As<IBackerService>();

            builder
               .RegisterType<ProjectServices>()
               .InstancePerLifetimeScope()
               .As<IProjectServices>();

            builder
                .RegisterType<CreatorServices>()
                .InstancePerLifetimeScope()
                .As<ICreatorService>();

            return builder.Build();
        }
    }
}