using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.Newborns
{
    public class NewbornUpdateRequest
    {   
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime Updated { get; set; }
        public Account Account { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}