using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFilters.Infractructure
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private string[] allowedUsers;

        public CustomAuthAttribute(params string[] users)
        {
            allowedUsers = users;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Request.IsAuthenticated && allowedUsers.Contains(httpContext.User.Identity.Name, StringComparer.InvariantCultureIgnoreCase);
        }

    }
}