﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Reply: Comment
    {
        // +Comment Reply
        public Comment ReplyComment { get; set; }
    }
}