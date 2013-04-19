using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using LoginPage.Domain;
using LoginPage.Domain.DB;

namespace LoginPage.Infrastructure.Installers
{
    public class LoginInstaller :IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<ICoreRepo>().ImplementedBy<CoreRepo>().LifestyleSingleton());
        }
    }
}