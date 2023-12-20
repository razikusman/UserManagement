﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using UserManagement.Models.Model;

namespace UserManagement.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute,IAuthorizationFilter
    {
        public CustomAuthorizeAttribute()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items[nameof(Employees)] as Employees;

            // if user not loged in throw out else keep the request go on(do nothing)
            if (user == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
    
}
