using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    class ListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //Not sure why I have an error here?
        public User Author { get; set; }
        //Not sure if I need this here?
        public Post CommentPost { get; set; }
    }

    //Post


    //Comment
}
