using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Africanbiomedtests.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<Role> _roles;

    public AuthorizeAttribute(params Role[] roles)
    {
        _roles = roles ?? new Role[] { };
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var account = (Account)context.HttpContext.Items["Account"];
        var hcp = (HealthcareProvider)context.HttpContext.Items["HealthcareProvider"];
       // if (account == null || (_roles.Any() && !_roles.Contains(account.Role)))
        
        if ((account == null ) && (hcp == null) || (_roles.Any() && !_roles.Contains(account.Role)))
        {
            // not logged in or role not authorized
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}