using System;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.Newborns
{
    public class NewbornAccountResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public Account Account { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
    }
}