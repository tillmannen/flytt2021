using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Account
{
    public class AuthMessageSenderOptions
    {
        public string SendGridKey { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromFriendlyName { get; set; }
    }
}
