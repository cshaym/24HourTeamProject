using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{// Make public, Data annotations, Properties, Using statements
    public class Like
    {
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
    }
}
