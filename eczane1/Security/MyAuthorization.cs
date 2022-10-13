using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eczane1.Security
{
    public class MyAuthorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
                base.OnAuthorization(filterContext);
            else
                filterContext.Result = new RedirectResult("/Login/Hata");

        }
    }
}