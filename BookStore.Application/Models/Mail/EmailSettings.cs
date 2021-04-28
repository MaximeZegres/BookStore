using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Models.Mail
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }

        public string FromAdress { get; set; }

        public string FromName { get; set; }
    }
}
