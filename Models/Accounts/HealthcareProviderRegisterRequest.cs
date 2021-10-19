using System.ComponentModel.DataAnnotations;

namespace Africanbiomedtests.Models.Accounts
{
    public class HealthcareProviderRegisterRequest
    {
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)")]
        public string HealthcareProviderName { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)")]
        public string CreatedByFullName { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)")]
        public string CreatedByDesignation { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }
                
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}