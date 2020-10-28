﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{// Make public, Data annotations, Properties, Using statements
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public Post CommentPost { get; set; }
    }
}