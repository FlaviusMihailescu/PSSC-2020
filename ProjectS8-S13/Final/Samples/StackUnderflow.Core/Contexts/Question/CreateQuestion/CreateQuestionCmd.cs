using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    public struct CreateQuestionCmd
    {
        public CreateQuestionCmd(int questionId, string title, string body, ICollection<string> tags, Guid userId, int tenantId)
        {
            QuestionId = questionId;
            Title = title;
            Body = body;
            Tags = tags;
            UserId = userId;
            TenantId = tenantId;

        }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public ICollection<string> Tags { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int TenantId { get; set; }
    }
}
