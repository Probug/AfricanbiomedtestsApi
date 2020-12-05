using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsResults
{
    public class MedTestsResultCreateRequest
    {

        [Required]
        public MedTest MedTest { get; set; }

        [Required]
        public Account Account { get; set; }

        [Required]
        public HealthcareProvider HealthcareProvider { get; set; }

        public Newborn Newborn { get; set; }

        [Required]
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Analysis { get; set; }
        public string Action { get; set; } 

    }
}