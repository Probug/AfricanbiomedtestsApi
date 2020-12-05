using System;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsOrder
{
    public class MedTestsOrderResponse
    {
        public int Id { get; set; }
        public MedTest MedTest { get; set; }
        public HealthcareProvider healthcareProvider { get; set; }
        public Account Account { get; set; }
        public Newborn Newborn { get; set; }
        public string PaymentStatus { get; set; }
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }

    }
}