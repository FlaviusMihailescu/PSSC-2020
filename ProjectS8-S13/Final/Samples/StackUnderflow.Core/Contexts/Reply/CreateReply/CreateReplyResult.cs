using Access.Primitives.Extensions.Cloning;
using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply.CreateReply
{
    [AsChoice]
    public static partial class CreateReplyResult
    {
        public interface ICreateReplyResult : IDynClonable { }

        public class ReplyCreated : ICreateReplyResult
        {
            public Post Post { get; }

            public ReplyCreated(Post post)
            {

                Post = post;
            }

            public object Clone() => this.ShallowClone();

        }

        public class ReplyNotCreated : ICreateReplyResult
        {
            public string Reason { get; private set; }

            ///TODO
            public object Clone() => this.ShallowClone();
        }

        public class InvalidRequest : ICreateReplyResult
        {
            public string Message { get; }

            public InvalidRequest(string message)
            {
                Message = message;
            }

            ///TODO
            public object Clone() => this.ShallowClone();
        }
    }
}
