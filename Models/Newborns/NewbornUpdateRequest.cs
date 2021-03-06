using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.Newborns
{
    public class NewbornUpdateRequest
    {
        //private string _password;
        //private string _confirmPassword;
        //private string _role;
        //private string _email;
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime Updated { get; set; }
        public Account Account { get; set; }
        //public string ZipCode { get; set; }

        // [EnumDataType(typeof(Role))]
        // public string Role
        // {
        //     get => _role;
        //     set => _role = replaceEmptyWithNull(value);
        // }

        // [EmailAddress]
        // public string Email
        // {
        //     get => _email;
        //     set => _email = replaceEmptyWithNull(value);
        // }

        // [MinLength(6)]
        // public string Password
        // {
        //     get => _password;
        //     set => _password = replaceEmptyWithNull(value);
        // }

        // [Compare("Password")]
        // public string ConfirmPassword 
        // {
        //     get => _confirmPassword;
        //     set => _confirmPassword = replaceEmptyWithNull(value);
        // }

        // helpers

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}