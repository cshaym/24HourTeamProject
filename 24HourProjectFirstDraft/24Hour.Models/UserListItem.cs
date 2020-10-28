using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{// Make class public, Add public properties, Data annotations, Using statements
    public class UserListItem
    {
        // Do we want one for the guid?: public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
