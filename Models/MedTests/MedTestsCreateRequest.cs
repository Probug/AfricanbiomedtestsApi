using System;
using System.ComponentModel.DataAnnotations;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Models.MedTests
{
    public class MedTestsCreateRequest
    {

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[0-9A-Za-z ]+$")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        //[Required]
        public DateTime Created { get; set; }

    }
}