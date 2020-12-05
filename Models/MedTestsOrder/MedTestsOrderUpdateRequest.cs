using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsOrder
{
    public class MedTestsOrderUpdateRequest
    {
        
        public int Id { get; set; }
        public MedTest MedTest { get; set; }
        public HealthcareProvider healthcareProvider { get; set; }
        public Account Account { get; set; }
        public Newborn Newborn { get; set; }
        public string PaymentStatus { get; set; }
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime Updated { get; set; }
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}