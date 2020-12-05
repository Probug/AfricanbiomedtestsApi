using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Models.Accounts;
using Africanbiomedtests.Models.MedTestsOrder;
using Africanbiomedtests.Services;

namespace Africanbiomedtests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedTestOrderController : BaseController
    {
        private readonly IMedTestOrderService _medTestOrderService;
        private readonly IMapper _mapper;

        public MedTestOrderController(
            IMedTestOrderService medTestOrderService,
            IMapper mapper)
        {
            _medTestOrderService = medTestOrderService;
            _mapper = mapper;
        }

        

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<MedTestsOrderResponse>> GetAll()
        {
            var medTestOrder = _medTestOrderService.GetAll();
            return Ok(medTestOrder);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<MedTestsOrderResponse> GetById(int id)
        {

            var medTestOrder = _medTestOrderService.GetById(id);
            return Ok(medTestOrder);
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<MedTestsOrderResponse> Create(MedTestsOrderCreateRequest model)
        {
            var medTestOrder = _medTestOrderService.Create(model);
            return Ok(medTestOrder);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<MedTestsOrderResponse> Update(int id, MedTestsOrderUpdateRequest model)
        {

            var medTestOrder = _medTestOrderService.Update(id, model);
            return Ok(medTestOrder);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            _medTestOrderService.Delete(id);
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