using System.ComponentModel.DataAnnotations;

namespace Africanbiomedtests.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}