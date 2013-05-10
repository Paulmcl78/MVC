using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure
{
    /// <summary>
    /// It is not recommended that you create you own factory but more extend the default.
    /// </summary>
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;

            switch (controllerName)
            {
                case "Home":
                    //we change the route data as views are displayed based on the route controller name
                    //not the controller class name, so to route this elsewhere we need to ensure we are
                    //also changing the routing data so that we do not break anythin further down the line.
                    requestContext.RouteData.Values["controller"] = "First";
                    targetType = typeof (FirstController);
                    break;
                case "First":
                    targetType = typeof (FirstController);
                    break;
                case "Second":
                    targetType = typeof (SecondController);
                    break;
            }

            return targetType == null ? null : (IController) Activator.CreateInstance(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
           return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}