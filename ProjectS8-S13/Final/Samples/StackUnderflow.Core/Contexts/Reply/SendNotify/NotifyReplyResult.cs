using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply.SendNotify
{
    public static partial class NotifyReplyResult
    {
        public interface INotifyReplyResult { }
        public class ReplyConfirmed : INotifyReplyResult
        {
            public User QuestionUser { get; }
            public string ConfirmationAcknowledgement { get; set; }

            public ReplyConfirmed(User questionUser, string confirmationAcknowledgement)
            {
                QuestionUser = questionUser;
                ConfirmationAcknowledgement = confirmationAcknowledgement;
            }
        }
        public class ReplayNotConfirmed : INotifyReplyResult
        {

        }
        public class InvalidRequest : INotifyReplyResult
        {
            public InvalidRequest(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }
}
