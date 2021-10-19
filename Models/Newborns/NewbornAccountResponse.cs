using System;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.Newborns
{
    public class NewbornAccountResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public Account Account { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
    }
}