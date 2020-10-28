﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{// Make public, Inherit from Comment, Data annotations, Properties, Using statements
    public class Reply: Comment
    {
        [Key]
        public int ReplyId { get; set; }
       
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

        
    }
}
