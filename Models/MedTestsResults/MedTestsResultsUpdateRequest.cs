using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsResults
{
    public class MedTestsResultUpdateRequest
    {
        public Guid Id { get; set; }
        public MedTest MedTest { get; set; }
        public Account Account { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
        public Newborn Newborn { get; set; }
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Analysis { get; set; }
        public string Action { get; set; } 
        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}