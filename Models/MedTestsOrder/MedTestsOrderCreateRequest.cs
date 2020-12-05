using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTestsOrder
{
    public class MedTestsOrderCreateRequest
    {
        public int Id { get; set; }

        [Required]
        public int? MedTestId { get; set; }
        [ForeignKey("MedTestId")]
        public MedTest MedTest { get; set; }
        public int? healthcareProviderId { get; set; }
        [ForeignKey("healthcareProviderId")]
        public HealthcareProvider healthcareProvider { get; set; }
        public int? accountId { get; set; }
        [ForeignKey("accountId")]
        public Account Account { get; set; }
        public int? newbornId { get; set; }
        [ForeignKey("newbornId")]
        public Newborn Newborn { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
        public Boolean CompletionStatus { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

    }
}