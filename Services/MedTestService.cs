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
using Africanbiomedtests.Models.MedTests;
using Microsoft.EntityFrameworkCore;

namespace Africanbiomedtests.Services
{
        public interface IMedTestService
    {
        IEnumerable<MedTestsAccountResponse> GetAll();
        MedTestsAccountResponse GetById(int id);
        MedTestsAccountResponse Create(MedTestsCreateRequest model);
        MedTestsAccountResponse Update(int id, MedTestsUpdateRequest model);
        void Delete(int id);
    }
    public class MedTestService : IMedTestService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedTestService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MedTestsAccountResponse> GetAll()
        {
            var medTests = _context.MedTest;
            return _mapper.Map<IList<MedTestsAccountResponse>>(medTests);
        }

        public MedTestsAccountResponse GetById(int id)
        {
            var medTest = getAccount(id);
            return _mapper.Map<MedTestsAccountResponse>(medTest);
        }

        public MedTestsAccountResponse Create(MedTestsCreateRequest model)
        {

            // map model to new account object
            var medTest = _mapper.Map<MedTest>(model);
            medTest.Created = DateTime.UtcNow;


            // save account
            _context.MedTest.Add(medTest);
            _context.SaveChanges();

            return _mapper.Map<MedTestsAccountResponse>(medTest);
        }

        public MedTestsAccountResponse Update(int id, MedTestsUpdateRequest model)
        {
            var medTest = getAccount(id);


            // copy model to account and save
            _mapper.Map(model, medTest);
            medTest.Updated = DateTime.UtcNow;
            _context.MedTest.Update(medTest);
            _context.SaveChanges();

            return _mapper.Map<MedTestsAccountResponse>(medTest);
        }

        public void Delete(int id)
        {
            var medTest = getAccount(id);
            _context.MedTest.Remove(medTest);
            _context.SaveChanges();
        }

        // helper methods

        private MedTest getAccount(int id)
        {
            var medTest = _context.MedTest.Find(id);
            if (medTest == null) throw new KeyNotFoundException("Account not found");
            return medTest;
        }

    }
}