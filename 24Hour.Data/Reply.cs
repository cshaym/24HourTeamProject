using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{// Make public, Inherit from Comment, Data annotations, Properties, Using statements
    public class Reply: Comment
    {
        public Comment ReplyComment { get; set; }
    }
}
