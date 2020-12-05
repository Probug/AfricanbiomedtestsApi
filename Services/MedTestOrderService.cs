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
using Africanbiomedtests.Models.MedTestsOrder;
using Microsoft.EntityFrameworkCore;

namespace Africanbiomedtests.Services
{
        public interface IMedTestOrderService
    {
        IEnumerable<MedTestsOrderResponse> GetAll();
        MedTestsOrderResponse GetById(int id);
        MedTestsOrderResponse Create(MedTestsOrderCreateRequest model);
        MedTestsOrderResponse Update(int id, MedTestsOrderUpdateRequest model);
        void Delete(int id);
    }
    public class MedTestOrderService : IMedTestOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedTestOrderService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MedTestsOrderResponse> GetAll()
        {
            var medTestOrder = _context.MedTestOrder;
            return _mapper.Map<IList<MedTestsOrderResponse>>(medTestOrder);
        }

        public MedTestsOrderResponse GetById(int id)
        {
            var medTestOrder = getAccount(id);
            return _mapper.Map<MedTestsOrderResponse>(medTestOrder);
        }

        public MedTestsOrderResponse Create(MedTestsOrderCreateRequest model)
        {

            // map model to new account object
            var medTestOrder = _mapper.Map<MedTestOrder>(model);
            medTestOrder.DateCreated = DateTime.UtcNow;


            // save account
            _context.MedTestOrder.Add(medTestOrder);
            _context.SaveChanges();

            return _mapper.Map<MedTestsOrderResponse>(medTestOrder);
        }

        public MedTestsOrderResponse Update(int id, MedTestsOrderUpdateRequest model)
        {
            var medTestOrder = getAccount(id);


            // copy model to account and save
            _mapper.Map(model, medTestOrder);
            medTestOrder.Updated = DateTime.UtcNow;
            _context.MedTestOrder.Update(medTestOrder);
            _context.SaveChanges();

            return _mapper.Map<MedTestsOrderResponse>(medTestOrder);
        }

        public void Delete(int id)
        {
            var medTestOrder = getAccount(id);
            _context.MedTestOrder.Remove(medTestOrder);
            _context.SaveChanges();
        }

        // helper methods

        private MedTestOrder getAccount(int id)
        {
            var medTestOrder = _context.MedTestOrder.Find(id);
            if (medTestOrder == null) throw new KeyNotFoundException("Account not found");
            return medTestOrder;
        }

    }
}