using System;
using System.Collections.Generic;
using System.Text;

namespace Question.domain4.PostedQuestionWorkflow
{
    public struct PostedQuestionCmd : IEquatable<PostedQuestionCmd>
    {
        public PostedQuestionCmd(string title, string body, string tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }

        [Required]
        public string Title { get; }
        [Required]
        public string Body { get; }
        [Required]
        public string Tags { get; }


        public bool Equals(PostedQuestionCmd other)
        {
            return Title == other.Title && Body == other.Body && Tags == other.Tags;
        }

        public override bool Equals(object obj)
        {
            return obj is PostedQuestionCmd other && Equals(other);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Body, Tags);
        }

    }
}

namespace Question.domain4.PostedQuestionWorkflow
{
    class RequiredAttribute : Attribute
    {
    }
}