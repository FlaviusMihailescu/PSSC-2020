using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.domain4.PostedQuestionWorkflow
{
    [AsChoice]
    public static partial class PostedQuestionResult
    {
        public interface IPostedQuestion
        {
        }

        public class QuestionPosted : IPostedQuestion
        {
            public Guid QuestionId { get; private set; }
            public string Body { get; private set; }

            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }

            public  QuestionPosted (IReadOnlyCollection<VoteEnum> allVotes, int voteCount)
            {
                VoteCount = voteCount;
                AllVotes = allVotes;
            }


            public QuestionPosted(Guid questionId, string body)
            {
                QuestionId = questionId;
                Body = body;
            }
        }

        public class QuestionNotPosted : IPostedQuestion
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        public class InvalidQuestion : IPostedQuestion
        {
            public IEnumerable<object> QuestionInvalid { get; private set; }

            public InvalidQuestion(IEnumerable<string> errors)
            {
                QuestionInvalid = errors.AsEnumerable();
            }

        }


    }
}
