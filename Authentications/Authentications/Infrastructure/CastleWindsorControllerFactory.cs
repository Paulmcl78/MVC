using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Authentication.Domain;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Authentications.Infrastructure
{
    public class CastleWindsorControllerFactory:DefaultControllerFactory
    {
      
        private readonly IKernel _kernel;

        public CastleWindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
         }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            
            
            return controllerType == null ? null : (IController)_kernel.Resolve(controllerType);
        }


        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }
    }
}