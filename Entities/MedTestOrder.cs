using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Africanbiomedtests.Entities
{
        public class MedTestOrder
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
        public string PaymentStatus { get; set; }
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime? Updated { get; set; }

    }

}