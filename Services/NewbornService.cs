using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Helpers;
using Africanbiomedtests.Models.Newborns;

namespace Africanbiomedtests.Services
{
        public interface INewbornService
    {
        //AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        //AuthenticateResponse RefreshToken(string token, string ipAddress);
        //void RevokeToken(string token, string ipAddress);
        //void Register(HealthcareProviderRegisterRequest model, string origin);
        //void VerifyEmail(string token);
        //void ForgotPassword(ForgotPasswordRequest model, string origin);
        //void ValidateResetToken(ValidateResetTokenRequest model);
       // void ResetPassword(ResetPasswordRequest model);
        IEnumerable<NewbornAccountResponse> GetAll();
        IEnumerable<NewbornAccountResponse> GetByHealthcareProvider(int healthcareProvider);
        NewbornAccountResponse GetById(int id);
        NewbornAccountResponse Create(NewbornCreateRequest model);
        NewbornAccountResponse Update(int id, NewbornUpdateRequest model);
        void Delete(int id);
    }
    public class NewbornService : INewbornService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        //private readonly AppSettings _appSettings;
        //private readonly IEmailService _emailService;

        public NewbornService(
            DataContext context,
            IMapper mapper)
            //IOptions<AppSettings> appSettings)
            //IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            //_appSettings = appSettings.Value;
           // _emailService = emailService;
        }

        public IEnumerable<NewbornAccountResponse> GetAll()
        {
            var newborns = _context.Newborns;
            return _mapper.Map<IList<NewbornAccountResponse>>(newborns);
        }

        //Return Newborn registered with Healthcare Provider
        public IEnumerable<NewbornAccountResponse> GetByHealthcareProvider(int healthcareProvider)
        {
            // if (_context.Newborns.Any(x => x.HealthCareProvider == _context.HealthcareProviders.SingleOrDefault(x => x.Id)))
            
            //  return _context.Newborns;
             var newborns = getAccounts(healthcareProvider);
               
            return _mapper.Map<IList<NewbornAccountResponse>>(newborns);
        }

        public NewbornAccountResponse GetById(int id)
        {
            var newborn = getAccount(id);
            return _mapper.Map<NewbornAccountResponse>(newborn);
        }

        public NewbornAccountResponse Create(NewbornCreateRequest model)
        {

            // map model to new account object
            var newborn = _mapper.Map<Newborn>(model);
            //newborn.HealthCareProvider = ;
            newborn.Created = DateTime.UtcNow;
            //newborn.Verified = DateTime.UtcNow;


            // save account
            _context.Newborns.Add(newborn);
            _context.SaveChanges();

            return _mapper.Map<NewbornAccountResponse>(newborn);
        }

        public NewbornAccountResponse Update(int id, NewbornUpdateRequest model)
        {
            var newborn = getAccount(id);

            // validate
            // if (newborn.Email != model.Email && _context.Newborns.Any(x => x.Email == model.Email))
            //     throw new AppException($"Email '{model.Email}' is already taken");

            // hash password if it was entered
            // if (!string.IsNullOrEmpty(model.Password))
            //     newborn.PasswordHash = BC.HashPassword(model.Password);

            // copy model to account and save
            _mapper.Map(model, newborn);
            newborn.Updated = DateTime.UtcNow;
            _context.Newborns.Update(newborn);
            _context.SaveChanges();

            return _mapper.Map<NewbornAccountResponse>(newborn);
        }

        public void Delete(int id)
        {
            var newborn = getAccount(id);
            _context.Newborns.Remove(newborn);
            _context.SaveChanges();
        }

        // helper methods

        private Newborn getAccount(int id)
        {
            var newborn = _context.Newborns.Find(id);
            if (newborn == null) throw new KeyNotFoundException("Account not found");
            return newborn;
        }

        //Trying to pass current HealthcareProvider.Id as a parameter
        private Newborn getAccounts(int HealthCareProvider)
        {
            var healthcareProvider = _context.Newborns.HealthcareProvider;

            var newborns = _context.Newborns
            .FromSqlInterpolated($"SELECT * FROM Newborn WHERE HealthcareProvider = {healthcareProvider}")
            .ToList();
        }
    }
}