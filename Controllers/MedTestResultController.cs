using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Models.MedTestsResults;
using Africanbiomedtests.Services;

namespace Africanbiomedtests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedTestResultsController : BaseController
    {
        private readonly IMedTestResultService _medTestResultService;
        private readonly IMapper _mapper;

        public MedTestResultsController(
            IMedTestResultService medTestResultService,
            IMapper mapper)
        {
            _medTestResultService = medTestResultService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<MedTestsResultResponse>> GetAll()
        {
            var medTestResults = _medTestResultService.GetAll();
            return Ok(medTestResults);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<MedTestsResultResponse> GetById(int id)
        {

            var medTestResult = _medTestResultService.GetById(id);
            return Ok(medTestResult);
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<MedTestsResultResponse> Create(MedTestsResultCreateRequest model)
        {
            var medTestResult = _medTestResultService.Create(model);
            return Ok(medTestResult);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<MedTestsResultResponse> Update(int id, MedTestsResultUpdateRequest model)
        {

            var medTestResult = _medTestResultService.Update(id, model);
            return Ok(medTestResult);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            _medTestResultService.Delete(id);
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