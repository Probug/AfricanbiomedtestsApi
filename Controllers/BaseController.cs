using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
        public HealthcareProvider HealthcareProvider => (HealthcareProvider)HttpContext.Items["HealthcareProvider"];
    }
}