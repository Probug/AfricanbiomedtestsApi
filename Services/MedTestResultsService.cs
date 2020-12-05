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
using Africanbiomedtests.Models.MedTestsResults;
using Microsoft.EntityFrameworkCore;

namespace Africanbiomedtests.Services
{
        public interface IMedTestResultService
    {
        IEnumerable<MedTestsResultResponse> GetAll();
        MedTestsResultResponse GetById(int id);
        MedTestsResultResponse Create(MedTestsResultCreateRequest model);
        MedTestsResultResponse Update(int id, MedTestsResultUpdateRequest model);
        void Delete(int id);
    }
    public class MedTestResultService : IMedTestResultService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedTestResultService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MedTestsResultResponse> GetAll()
        {
            var medTestResult = _context.MedTestResult;
            return _mapper.Map<IList<MedTestsResultResponse>>(medTestResult);
        }

        public MedTestsResultResponse GetById(int id)
        {
            var medTestResult = getAccount(id);
            return _mapper.Map<MedTestsResultResponse>(medTestResult);
        }

        public MedTestsResultResponse Create(MedTestsResultCreateRequest model)
        {

            // map model to new account object
            var medTestResult = _mapper.Map<MedTestResult>(model);
            medTestResult.DateCreated = DateTime.UtcNow;

            // save account
            _context.MedTestResult.Add(medTestResult);
            _context.SaveChanges();

            return _mapper.Map<MedTestsResultResponse>(medTestResult);
        }

        public MedTestsResultResponse Update(int id, MedTestsResultUpdateRequest model)
        {
            var medTestResults = getAccount(id);


            // copy model to account and save
            _mapper.Map(model, medTestResults);
            medTestResults.Updated = DateTime.UtcNow;
            _context.MedTestResult.Update(medTestResults);
            _context.SaveChanges();

            return _mapper.Map<MedTestsResultResponse>(medTestResults);
        }

        public void Delete(int id)
        {
            var medTestResults = getAccount(id);
            _context.MedTestResult.Remove(medTestResults);
            _context.SaveChanges();
        }

        // helper methods

        private MedTestResult getAccount(int id)
        {
            var medTestResults = _context.MedTestResult.Find(id);
            if (medTestResults == null) throw new KeyNotFoundException("Account not found");
            return medTestResults;
        }

    }
}