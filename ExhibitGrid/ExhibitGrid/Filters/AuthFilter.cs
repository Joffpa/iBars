using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExhibitGrid.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var x = filterContext.HttpContext.Request;
        }
    }
}