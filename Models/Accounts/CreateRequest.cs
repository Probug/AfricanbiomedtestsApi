using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.Accounts
{
    public class CreateRequest
    {
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)")]
        public string FullName { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public bool AcceptTerms { get; set; }
    }
}