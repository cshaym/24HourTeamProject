using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{// Make class public, Add public properties, Data annotations, Using statements
    public class ReplyListItem
    {
        [Display(Name = "Reply")]   // On screen the user should see "Reply" instead of the class name "ReplyComment"
        public Comment ReplyComment { get; set; }
    }
}
