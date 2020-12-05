using System;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsResults
{
    public class MedTestsResultResponse
    {
        public int Id { get; set; }
        public MedTest MedTest { get; set; }
        public Account Account { get; set; }
        public HealthcareProvider healthcareProvider { get; set; }
        public Newborn Newborn { get; set; }
        public DateTime DateCreated { get; set; }
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Analysis { get; set; }
        public string Action { get; set; } 
    }
}