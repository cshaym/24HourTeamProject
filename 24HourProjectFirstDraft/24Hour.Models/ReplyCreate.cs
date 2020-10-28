using _24Hour.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{// Make public, Properties, Data annotations, Using statements
    public class ReplyCreate
    {
        [Required]  // Required to write a response in order to prevent submitting a blank response or is that what the MinLength is for?
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(8000, ErrorMessage = "Please have no more than 8000 characters.")]
        public Comment ReplyComment { get; set; }
    }
}
