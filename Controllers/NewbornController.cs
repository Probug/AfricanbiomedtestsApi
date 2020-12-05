using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Models.Newborns;
using Africanbiomedtests.Services;

namespace Africanbiomedtests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewbornController : BaseController
    {
        private readonly INewbornService _newbornService;
        private readonly IMapper _mapper;

        public NewbornController(
            INewbornService newbornService,
            IMapper mapper)
        {
            _newbornService = newbornService;
            _mapper = mapper;
        }

        

        [Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<NewbornAccountResponse>> GetAll()
        {
            var newborns = _newbornService.GetAll();
            return Ok(newborns);
        }

        // [Authorize]
        // [HttpGet]
        // public ActionResult<IEnumerable<NewbornAccountResponse>> GetByHealthcareProvider()
        // {
        //     //HealthcareProvider can get Newborn accounts registered with them
        //     if (Newborn.HealthcareProvider == HealthcareProvider.Id)
        //     {
        //         var newborns = _newbornService.GetByHealthcareProvider();
                
        //     }else
        //     {
        //         return Unauthorized(new { message = "Unauthorized Access" });
        //     }
        //       return Ok(newborns);  
            
        // }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<NewbornAccountResponse> GetById(int id)
        {
            // int newbornHealthcareProvider = Convert.ToInt32(Newborn.HealthcareProvider);
            // //Healthcare Providers can get related accounts and admins can get any account
            // if (newbornHealthcareProvider != HealthcareProvider.Id && Account.Role != Role.Admin)
            //     return Unauthorized(new { message = "Unauthorized" });

            var newborn = _newbornService.GetById(id);
            return Ok(newborn);
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<NewbornAccountResponse> Create(NewbornCreateRequest model)
        {
            var account = _newbornService.Create(model);
            return Ok(account);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<NewbornAccountResponse> Update(int id, NewbornUpdateRequest model)
        {
            // int newbornHealthcareProvider = Convert.ToInt32(Newborn.HealthcareProvider);
            // // users can update their own account and admins can update any account
            //  if (newbornHealthcareProvider != HealthcareProvider.Id && Account.Role != Role.Admin)
            //     return Unauthorized(new { message = "Unauthorized" });

            // only admins can update role
            //if (Account.Role != Role.Admin)
                //model.Role = null;

            var newborn = _newbornService.Update(id, model);
            return Ok(newborn);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // int newbornHealthcareProvider = Convert.ToInt32(Newborn.HealthcareProvider);
            // // users can delete their own account and admins can delete any account
            //  if (newbornHealthcareProvider != HealthcareProvider.Id && Account.Role != Role.Admin)
            //      return Unauthorized(new { message = "Unauthorized" });

            _newbornService.Delete(id);
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