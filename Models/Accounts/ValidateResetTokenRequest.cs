using System.ComponentModel.DataAnnotations;

namespace Africanbiomedtests.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}