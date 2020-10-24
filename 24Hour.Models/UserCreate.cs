using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{// Make public, Properties, Data annotations, Using statements
    public class UserCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(30, ErrorMessage = "Please enter no more than 30 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Please enter a valid email address.")]    // do we need a minimum?
        public string Email { get; set; }
    }
}
