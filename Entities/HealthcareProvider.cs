using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Africanbiomedtests.Entities
{
        public class HealthcareProvider
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string HealthcareProviderName { get; set; }
        public string CreatedByFullName { get; set; }
        public string CreatedByDesignation { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PasswordHash { get; set; }
        public bool AcceptTerms { get; set; }
        public Role Role { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public ICollection<Account> Account { get; set; } // Linked Table        
        public ICollection<Newborn> Newborn { get; set; } // Linked Table
        public ICollection<MedTest> MedTest { get; set; } // Linked Table
        public ICollection<MedTestOrder> MedTestOrder { get; set; } // Linked Table
        public ICollection<MedTestResult> MedTestResult { get; set; } // Linked Table
        public bool OwnsToken(string token) 
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }

}