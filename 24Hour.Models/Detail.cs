using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    class Detail
    {
        //Post Class
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public Post CommentPost { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifyUtc { get; set; }
    }



    //Comment
}
