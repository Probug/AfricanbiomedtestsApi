using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsResults
{
    public class MedTestsResultCreateRequest
    {
        public Guid Id { get; set; }
        public Guid MedTestId { get; set; }
        [ForeignKey("MedTestId")]
        public MedTest MedTest { get; set; }
        public Guid HealthcareProviderId { get; set; }
        [ForeignKey("HealthcareProviderId")]
        public HealthcareProvider HealthcareProvider { get; set; }
        public Guid AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public Guid NewbornId { get; set; }
        [ForeignKey("NewbornId")]
        public Newborn Newborn { get; set; }

        [Required]
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Analysis { get; set; }
        public string Action { get; set; } 

    }
}