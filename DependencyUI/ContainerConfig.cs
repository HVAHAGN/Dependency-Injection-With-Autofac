using Autofac;
using Autofac.Core;
using DemoLibrary;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<Application>().As<IApplication>();

            //for automatation
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t=>t.Namespace.Contains("Utilities"))
                .As(t=>t.GetInterfaces().FirstOrDefault(i=>i.Name=="I"+t.Name));



            return builder.Build();

        }
    }
}
