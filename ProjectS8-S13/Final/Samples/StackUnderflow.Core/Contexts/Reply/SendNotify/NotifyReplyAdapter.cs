using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Access.Primitives.IO.Mocking;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Reply.SendNotify.NotifyReplyResult;

namespace StackUnderflow.Domain.Core.Contexts.Reply.SendNotify
{
    public partial class NotifyReplyAdapter : Adapter<NotifyReplyCmd, INotifyReplyResult, ReplyWriteContext, ReplyDependencies>
    {
        private readonly IExecutionContext _ex;
        public NotifyReplyAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }
        public override async Task<INotifyReplyResult> Work(NotifyReplyCmd command, ReplyWriteContext state, ReplyDependencies dependencies)
        {
            var wf = from isValid in command.TryValidate()
                     from user in command.QuestionUser.ToTryAsync()
                     let letter = GenerateConfirmationLetter(user)
                     from notifyAcknowledgement in dependencies.SendNotifyEmail(letter)
                     select (user, notifyAcknowledgement);
            return await wf.Match(
                Succ: r => new ReplyConfirmed(r.user, r.notifyAcknowledgement.Receipt),
                Fail: Exception => (INotifyReplyResult)new Question.CreateQuestion.CreateQuestionResult.InvalidRequest(Exception.ToString()));
        }
        private NotifyLetter GenerateConfirmationLetter(User user)
        {
            var link = $"https://stackunderflow/Question1231234";
            var letter = $@"Dear {user.DisplayName} your reply is posted. For details please click on {link}";
            return new NotifyLetter(user.Email, letter, new Uri(link));
        }


        public override Task PostConditions(NotifyReplyCmd cmd, NotifyReplyResult.INotifyReplyResult result, ReplyWriteContext state)
        {
            throw new NotImplementedException();
        }
    }
}
