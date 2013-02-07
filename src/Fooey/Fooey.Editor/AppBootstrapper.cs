using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Caliburn.Micro;
using Fooey.Editor.Framework;
using Fooey.Editor.ViewModels;

namespace Fooey.Editor
{
    internal class AppBootstrapper : Caliburn.Micro.Autofac.AutofacBootstrapper<IShell>
    {
        protected override void ConfigureContainer(Autofac.ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(this.GetType().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterType<ShellViewModel>().AsImplementedInterfaces().AsSelf().SingleInstance();
            base.ConfigureContainer(builder);
        }
    }
}
