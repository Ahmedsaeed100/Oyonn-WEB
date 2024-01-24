using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using System.Web.Mvc;
using System.Web.Routing;

using OyonnBL.DTO;

namespace Oyonn
{
    public class AuthorizeToken : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            //  if (!httpContext.User.Identity.IsAuthenticated)
            //  {
            //      return false;
            //  }
            //  var CurrentUser = httpContext.User.Identity.Name;
            ////  PostActivityUpdate(Controller, CurrentUser, AccessLevel);

            if (httpContext.Session["UserData"] != null)
            {
                AdminDTO user = (AdminDTO)httpContext.Session["UserData"];


                return true;

            }
            else
                return false;
            //  ;
            //return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Admin",
                                action = "Login"
                            })
                        );
        }

    }
}