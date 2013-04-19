using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;

namespace LoginPage.Infrastructure.Installers
{
    public class ControllerInstaller :IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly()).BasedOn<IController>().LifestyleTransient());
        }
    }
}