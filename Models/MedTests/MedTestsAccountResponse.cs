using System;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTests
{
    public class MedTestsAccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }

    }
}