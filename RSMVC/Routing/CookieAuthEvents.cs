using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RSMVC.Routing
{
    public class CookieAuthEvents : CookieAuthenticationEvents
    {
        public override Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.RedirectUri = "/Account/Login";
            return base.RedirectToLogin(context);
        }

        public override Task RedirectToLogout(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.RedirectUri = "/Account/Logout";
            return base.RedirectToLogout(context);
        }

        public override Task RedirectToAccessDenied(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.RedirectUri = "/Account/AccessDenied";
            return base.RedirectToAccessDenied(context);
        }

        public override Task RedirectToReturnUrl(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.RedirectUri = "/ReturnUrl";
            return base.RedirectToReturnUrl(context);
        }
    }
}

