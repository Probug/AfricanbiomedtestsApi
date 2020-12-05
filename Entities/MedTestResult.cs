using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Africanbiomedtests.Entities
{
        public class MedTestResult
    {
        [Key]
        public int Id { get; set; }
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
        public DateTime DateCreated { get; set; }
        public Boolean CompletionStatus { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Analysis { get; set; }
        public string Action { get; set; }     
        public DateTime? Updated { get; set; }
    }

}