using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Access.Primitives.IO.Mocking;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Reply.CreateReply.CreateReplyResult;

namespace StackUnderflow.Domain.Core.Contexts.Reply.CreateReply
{
    public partial class CreateQuestionAdapter : Adapter<CreateReplyCmd, ICreateReplyResult, ReplyWriteContext, ReplyDependencies>
    {
        private readonly IExecutionContext _ex;
        public CreateQuestionAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }
        public override async Task<ICreateReplyResult> Work(CreateReplyCmd command, ReplyWriteContext state, ReplyDependencies dependencies)
        {
            var workflow = from valid in command.TryValidate()
                           let t = AddQuestionMissing(state, CreateQuestionFromCommand(command))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new InvalidRequest(ex.ToString()));
            return result;
        }

        public ICreateReplyResult AddQuestionMissing(ReplyWriteContext state, Post reply)
        {
            if (state.Replys.Any(p => p.Title.Equals(reply.Title))) ////////////////
                return new ReplyNotCreated();

            if (state.Replys.All(p => p.PostId != reply.PostId))
                state.Replys.Add(reply);
            return new ReplyCreated(reply);
        }

        private Post CreateQuestionFromCommand(CreateReplyCmd cmd)
        {
            var post = new Post()
            {
                PostText = cmd.Body
            };

            return post;
        }
        public override Task PostConditions(CreateReplyCmd op, CreateReplyResult.ICreateReplyResult result, ReplyWriteContext state)
        {
            return Task.CompletedTask;
        }
    }
}
