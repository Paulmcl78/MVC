using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFilters.Infractructure
{
    public class OrAuthorizationAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Request.IsLocal || base.AuthorizeCore(httpContext);
        }
    }
}