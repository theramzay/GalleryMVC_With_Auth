using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleryMVC_With_Auth.Resources
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class MultiAuth : AuthorizeAttribute
    {
        public MultiAuth(params object[] userProfilesRequired)
        {
            if (userProfilesRequired.Any(p => p.GetType().BaseType != typeof (Enum)))
                throw new ArgumentException("userProfilesRequired");

            UserProfilesRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
        }

        private string[] UserProfilesRequired { get; }

        public override void OnAuthorization(AuthorizationContext context)
        {
            var authorized = false;

            foreach (var role in UserProfilesRequired)
                if (HttpContext.Current.User.IsInRole(role))
                {
                    authorized = true;
                    break;
                }

            if (!authorized)
            {
                var url = new UrlHelper(context.RequestContext);
                //var logonUrl = url.Action("Http", "Error", new {Id = 401, Area = ""});
                var logonUrl = url.Action("Login", "Account");
                context.Result = new RedirectResult(logonUrl);
            }
        }
    }
}