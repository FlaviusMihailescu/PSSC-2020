using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply.SendNotify
{
    public class NotifyLetter
    {
        public string Email { get; private set; }
        public string Letter { get; private set; }
        public Uri ConfirmationLink { get; private set; }

        public NotifyLetter(string email, string letter, Uri link)
        {
            Email = email;
            Letter = letter;
            ConfirmationLink = link;
        }
    }
}
