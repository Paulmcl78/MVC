using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Authentication.Domain;
using Authentications.Operations;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Authentications.Infrastructure
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserRepo>().ImplementedBy<UserRepo>().LifestyleSingleton());
            container.Register(Component.For<IAuthentication>().ImplementedBy<Authentication.Operations.Authentication>().LifestyleSingleton());
        }
    }
}