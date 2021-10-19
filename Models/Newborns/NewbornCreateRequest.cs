using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.Newborns
{
    public class NewbornCreateRequest
    {

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        //[Required]
        public DateTime Created { get; set; }
        public Guid HealthcareProviderId { get; set; }
        [ForeignKey("HealthcareProviderId")]
        public HealthcareProvider HealthcareProvider { get; set; }
        public Guid AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

    }
}