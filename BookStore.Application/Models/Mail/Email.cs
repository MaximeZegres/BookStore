﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Models.Mail
{
    public class Email
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
