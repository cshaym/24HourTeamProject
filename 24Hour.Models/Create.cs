using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class Create
    {
        [Required]
        public string Title { get; set; }
        public string Post { get; set; }
        public string Comments { get; set; }
    }

}
