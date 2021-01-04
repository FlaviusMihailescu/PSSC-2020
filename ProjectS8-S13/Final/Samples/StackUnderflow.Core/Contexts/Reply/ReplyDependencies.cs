using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Reply.SendNotify;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply
{
    public class ReplyDependencies
    {
        public Func<NotifyLetter, TryAsync<NotifyAcknowledgement>> SendNotifyEmail { get; set; }
    }
}
