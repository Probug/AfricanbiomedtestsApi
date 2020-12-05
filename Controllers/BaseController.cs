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
        public Newborn Newborn => (Newborn)HttpContext.Items["Newborn"];
        public MedTest MedTests => (MedTest)HttpContext.Items["MedTest"];
        public MedTestOrder MedTestOrder => (MedTestOrder)HttpContext.Items["MedTestOrder"];
        public MedTestResult MedTestResult => (MedTestResult)HttpContext.Items["MedTestResult"];
    }
}