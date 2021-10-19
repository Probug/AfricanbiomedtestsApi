using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsOrder
{
    public class MedTestsOrderCreateRequest
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
        public string PaymentStatus { get; set; }
        public Boolean CompletionStatus { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

    }
}