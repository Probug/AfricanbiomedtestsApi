using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Models.Accounts;
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

        // [HttpPost("authenticate")]
        // public ActionResult<AuthenticateRequest> Authenticate(AuthenticateRequest model)
        // {
        //     var response = _accountService.Authenticate(model, ipAddress());
        //     setTokenCookie(response.RefreshToken);
        //     return Ok(response);
        // }

        // [HttpPost("refresh-token")]
        // public ActionResult<AuthenticateResponse> RefreshToken()
        // {
        //     var refreshToken = Request.Cookies["refreshToken"];
        //     var response = _accountService.RefreshToken(refreshToken, ipAddress());
        //     setTokenCookie(response.RefreshToken);
        //     return Ok(response);
        // }

        // [Authorize]
        // [HttpPost("revoke-token")]
        // public IActionResult RevokeToken(RevokeTokenRequest model)
        // {
        //     // accept token from request body or cookie
        //     var token = model.Token ?? Request.Cookies["refreshToken"];

        //     if (string.IsNullOrEmpty(token))
        //         return BadRequest(new { message = "Token is required" });

        //     // users can revoke their own tokens and admins can revoke any tokens
        //     if (!HealthcareProvider.OwnsToken(token) && Account.Role != Role.Admin)
        //         return Unauthorized(new { message = "Unauthorized" });

        //     _accountService.RevokeToken(token, ipAddress());
        //     return Ok(new { message = "Token revoked" });
        // }

        // [HttpPost("register")]
        // public IActionResult Register(HealthcareProviderRegisterRequest model)
        // {
        //     _accountService.Register(model, Request.Headers["origin"]);
        //     return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        // }

        // [HttpPost("verify-email")]
        // public IActionResult VerifyEmail(VerifyEmailRequest model)
        // {
        //     _accountService.VerifyEmail(model.Token);
        //     return Ok(new { message = "Verification successful, you can now login" });
        // }

        // [HttpPost("forgot-password")]
        // public IActionResult ForgotPassword(ForgotPasswordRequest model)
        // {
        //     _accountService.ForgotPassword(model, Request.Headers["origin"]);
        //     return Ok(new { message = "Please check your email for password reset instructions" });
        // }

        // [HttpPost("validate-reset-token")]
        // public IActionResult ValidateResetToken(ValidateResetTokenRequest model)
        // {
        //     _accountService.ValidateResetToken(model);
        //     return Ok(new { message = "Token is valid" });
        // }

        // [HttpPost("reset-password")]
        // public IActionResult ResetPassword(ResetPasswordRequest model)
        // {
        //     _accountService.ResetPassword(model);
        //     return Ok(new { message = "Password reset successful, you can now login" });
        // }

        [Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<NewbornAccountResponse>> GetAll()
        {
            var newborns = _newbornService.GetAll();
            return Ok(newborns);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<NewbornAccountResponse>> GetByHealthcareProvider()
        {
            //HealthcareProvider can get Newborn accounts registered with them
            if (Newborn.HealthcareProvider == HealthcareProvider.Id)
            {
                var newborns = _newbornService.GetByHealthcareProvider();
                
            }else
            {
                return Unauthorized(new { message = "Unauthorized Access" });
            }
              return Ok(newborns);  
            
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<NewbornAccountResponse> GetById(int id)
        {
            //Healthcare Providers can get related accounts and admins can get any account
            if (Newborn.HealthcareProvider != HealthcareProvider.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var newborn = _newbornService.GetById(id);
            return Ok(newborn);
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<NewbornAccountResponse> Create(NewbornCreateRequest model)
        {
            var account = _newbornsService.Create(model);
            return Ok(account);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<NewbornAccountResponse> Update(int id, NewbornUpdateRequest model)
        {
            // users can update their own account and admins can update any account
            if (id != HealthcareProvider.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

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
            // users can delete their own account and admins can delete any account
            if (id != HealthcareProvider.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

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