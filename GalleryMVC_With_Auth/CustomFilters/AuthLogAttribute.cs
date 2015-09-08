﻿using System.Web.Mvc;

namespace GalleryMVC_With_Auth.CustomFilters
{
    public class AuthLogAttribute : AuthorizeAttribute
    {
        public AuthLogAttribute()
        {
            View = "AuthorizeFailed";
        }

        public string View { get; set; }

        /// <summary>
        ///     Check for Authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        /// <summary>
        ///     Method to check if the user is Authorized or not
        ///     if yes continue to perform the action else redirect to error page
        /// </summary>
        /// <param name="filterContext"></param>
        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            // If the Result returns null then the user is Authorized 
            if (filterContext.Result == null)
                return;

            //If the user is Un-Authorized then Navigate to Auth Failed View 
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // var result = new ViewResult { ViewName = View };
                var vr = new ViewResult {ViewName = View};

                var dict = new ViewDataDictionary
                {
                    {"Message", "Извините, но это действие не доступно для вашего уровня доступа!"}
                };

                vr.ViewData = dict;

                var result = vr;

                filterContext.Result = result;
            }
        }
    }
}