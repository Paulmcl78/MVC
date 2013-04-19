using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;
using System.Web.Routing;

namespace LoginPage.Infrastructure
{
    public class WindsorControllerFactory :DefaultControllerFactory
    {
        private IKernel _kernal;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernal = kernel;
        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernal.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _kernal.ReleaseComponent(controller);
        }
    }
}