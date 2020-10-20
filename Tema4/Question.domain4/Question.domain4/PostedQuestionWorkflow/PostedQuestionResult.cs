using System;
using System.Collections.Generic;
using System.Text;

namespace Question.domain4.PostedQuestionWorkflow
{
    public static partial class PostedQuestionResult
    {
        public interface IPostedQuestion
        {
        }

        public class QuestionPosted : IPostedQuestion
        {
            public QuestionPosted(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }

        public class QuestionNotPosted : IPostedQuestion
        {
            public QuestionNotPosted(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; }
        }
        public class InvalidQuestion : IPostedQuestion
        {
            public InvalidQuestion(PostedQuestionCmd cmd)
            {
                Cmd = cmd;
            }

            public PostedQuestionCmd Cmd { get; }
        }


    }
}
