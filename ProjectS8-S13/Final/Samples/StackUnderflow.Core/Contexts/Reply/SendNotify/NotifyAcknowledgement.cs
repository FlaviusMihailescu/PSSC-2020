using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply.SendNotify
{
    public class NotifyAcknowledgement
    {
        public NotifyAcknowledgement(string receipt)
        {
            Receipt = receipt;
        }
        public string Receipt { get; private set; }
    }
}
