using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDB.Shared.Models
{
    public class User
    {
        [Required]
        public int NationalId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(14, 75)]
        public int Age { get; set; }

        public DateTime DOB { get; set; }


        [Required]
        public string Gender { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public bool Terms { get; set; }


        // [Required]
        // [Range(1, int.MaxValue, ErrorMessage = "Please Select Location")]
        public string City {get;set;}
    }
}