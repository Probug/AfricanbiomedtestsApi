using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Models.MedTests;
using Africanbiomedtests.Services;

namespace Africanbiomedtests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedTestsController : BaseController
    {
        private readonly IMedTestService _medTestsService;
        private readonly IMapper _mapper;

        public MedTestsController(
            IMedTestService medTestsService,
            IMapper mapper)
        {
            _medTestsService = medTestsService;
            _mapper = mapper;
        }

        

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<MedTestsAccountResponse>> GetAll()
        {
            var medTests = _medTestsService.GetAll();
            return Ok(medTests);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<MedTestsAccountResponse> GetById(int id)
        {
            var medTest = _medTestsService.GetById(id);
            return Ok(medTest);
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<MedTestsAccountResponse> Create(MedTestsCreateRequest model)
        {
            var medTest = _medTestsService.Create(model);
            return Ok(medTest);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<MedTestsAccountResponse> Update(int id, MedTestsUpdateRequest model)
        {
            var medTest = _medTestsService.Update(id, model);
            return Ok(medTest);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _medTestsService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }

        // helper methods

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}