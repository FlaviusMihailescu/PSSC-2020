using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply
{
    public class ReplyWriteContext
    {
        public ICollection<Post> Replys { get; }

        public ReplyWriteContext(ICollection<Post> replys)
        {
            replys = replys ?? new List<Post>(0);
        }
    }
}
