using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Africanbiomedtests.Entities
{
        public class Newborn
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public Account Account { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        // public List<RefreshToken> RefreshTokens { get; set; }

        // public bool OwnsToken(string token) 
        // {
        //     return this.RefreshTokens?.Find(x => x.Token == token) != null;
        // }
    }

}