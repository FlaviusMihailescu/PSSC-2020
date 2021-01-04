using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply.CreateReply
{
    public struct CreateReplyCmd
    {
        public CreateReplyCmd(int questionId, Guid userId, string body)
        {
            QuestionId = questionId;
            UserId = userId;
            Body = body;
        }

        [Required]
        public string Body { get; private set; }
        [Required]
        public int QuestionId { get; private set; }
        [Required]
        public Guid UserId { get; private set; }
    }
}
